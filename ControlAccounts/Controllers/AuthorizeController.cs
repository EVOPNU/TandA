using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ControlAccounts.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using ControlAccounts.PostModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;
using System.Text;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ControlAccounts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {

        private readonly IOptions<AuthOptions> options;
        public AuthorizeController(IOptions<AuthOptions> options)
        {
            this.options = options;

        }


        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] Login login)
        {
            Console.WriteLine("To login");
            var user = AuthenticateUser(login.Email, login.Password);

            if (user != null)
            {
                var token = GenerateJWT(user);
                return Ok(new { access_token = token });
                //generate jwt
            }
            return Unauthorized();

        }

        private Account AuthenticateUser(string email, string password)
        {
            using ApplicationContext db = new ApplicationContext();
            {
                foreach (var l in db.account.ToList())
                {
                    if (l.email == email && l.password == GetHashString( password))
                    {
                        return l;
                    }
                }

            }
            return null;

        }




        [Route("Register")]
        [HttpPost]
        public IActionResult Register([FromBody] Login login)
        {
            if (login != null)
            {
                using ApplicationContext db = new ApplicationContext();
                {
                    foreach (var l in db.account.ToList())
                    {
                        if (l.email == login.Email)
                        {
                            return BadRequest("AlredyExist"); //какой код то
                        }
                    }

                    db.account.Add(new Account { email = login.Email, password = GetHashString( login.Password), role = "User", name = login.Name });
                    db.SaveChanges();
                    return Ok();

                }

            }
            return BadRequest(); //шо це таке 
        }
        string GetHashString(string s)
        {
            //переводим строку в байт-массим
            byte[] bytes = Encoding.Unicode.GetBytes(s);

            //создаем объект для получения средст шифрования
            MD5CryptoServiceProvider CSP =
                new MD5CryptoServiceProvider();

            //вычисляем хеш-представление в байтах
            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;

            //формируем одну цельную строку из массива
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;
        }


        [Route("Valid")]
        [HttpGet]
        [Authorize]
        public IActionResult Valid()
        {
           // var stream = 
            //Console.WriteLine(header);
            //string jsonToken = header.Remove(0,7);
           // Console.WriteLine(stream);
            var jsonToken = new JwtSecurityTokenHandler().ReadToken(Request.Headers["Authorization"].ToString().Remove(0, 7));
          //  var jsonToken = handler.ReadToken(stream);
            var tokenS = jsonToken as JwtSecurityToken;
            var jti = tokenS.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Sub).Value;

            return Ok(new { id = jti });
        }
        private string GenerateJWT(Account user)
        {
            string role;
            using ApplicationContext db = new ApplicationContext();
            { 
                role = db.account.FirstOrDefault(a=>a.email == user.email).role;
            }
                var authParams = options.Value;
            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentinals = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email,user.email),
                new Claim(JwtRegisteredClaimNames.Sub,user.id.ToString()),
               // new Claim(ClaimsIdentity.DefaultRoleClaimType,"Admin"),
                new Claim("role",role)
                //new Claim(JwtRegisteredClaimNames.Iss,authParams.Issure)
            };
            //foreach(var role in user.Role)
            //{
            //    claims.Add(new Claim("role",role.ToString()));

            //}

            var token = new JwtSecurityToken(authParams.Issure,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
                signingCredentials: credentinals);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
