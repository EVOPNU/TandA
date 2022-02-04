using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ControlAccounts.Models;
using ControlAccounts.PostModels;

namespace ControlAccounts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountController : ControllerBase
    {

        [Route("")]
        [HttpGet("{id}")]
        [Authorize(Roles = "User,Admin")]
        public IActionResult OnLoged(int id)
        {
            using ApplicationContext db = new ApplicationContext();
            {
                return Ok(db.accounts.FirstOrDefault(a => a.Id == id));
            }
            return Unauthorized();
        }

       

        //[Route("historyorders")]
        //[HttpPost]
        //[Authorize(Roles = "User")]
        //public IActionResult HistoryOrders([FromBody] int id)
        //{
        //    using ApplicationContext db = new ApplicationContext();
        //    {
        //        return Ok(db.accounts.FirstOrDefault(a => a.Identificator == id));
        //    }
        //}


        //puuut

        [Route("changepassword")]
        [HttpPut]
        [Authorize(Roles = "User,Admin")]
        public IActionResult ChangePassword([FromBody] Login login)
        {
            using ApplicationContext db = new ApplicationContext();
            {
                foreach (var l in db.accounts.ToList())
                {
                    if (l.Email == login.Email && l.Password == login.Password)
                    {
                        l.Password = login.Name;
                        db.SaveChanges();
                        return Ok(l);
                        //тестиииить
                    }
                }

            }
            return BadRequest();

        }

        [Route("changeemail")]
        [HttpPut]
        [Authorize(Roles = "User,Admin")]
        public IActionResult ChangeEmail([FromBody] LoginE loginE)
        {
            using ApplicationContext db = new ApplicationContext();
            {
                foreach (var l in db.accounts.ToList())
                {
                    if (l.Email == loginE.Email && l.Password == loginE.Password)
                    {
                        l.Email = loginE.NewEmail;
                        db.SaveChanges();
                        return Ok(l);
                        //тестиииить
                    }
                }

            }
            return BadRequest();
        }


        [Route("changename")]
        [HttpPut]
        [Authorize(Roles = "User,Admin")]
        public IActionResult ChangeName([FromBody]Login login)
        {
            using ApplicationContext db = new ApplicationContext();
            {
                foreach (var l in db.accounts.ToList())
                {
                    if (l.Email == login.Email && l.Password == login.Password)
                    {
                        l.Name = login.Name;
                        db.SaveChanges();
                        return Ok(l);
                        //тестиииить
                    }
                }

            }
            return BadRequest();

        }

        [Route("addmoney")]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult ChangeMoneyMul([FromBody] OperationCout model)
        {
            using ApplicationContext db = new ApplicationContext();
            {
                foreach (var l in db.accounts.ToList())
                {
                    if (l.Id == model.id)
                    {
                        l.Money = l.Money + model.count;
                        db.SaveChanges();
                        return Ok(l);
                        //тестиииить
                    }
                }

            }
            return BadRequest();

        }

        [Route("minusmoney")]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult ChangeMoneyMin([FromBody] OperationCout model)
        {
            using ApplicationContext db = new ApplicationContext();
            {
                foreach (var l in db.accounts.ToList())
                {
                    if (l.Id== model.id && l.Money > model.count)
                    {
                        l.Money = l.Money - model.count;
                        db.SaveChanges();
                        return Ok(l);
                        //добавить если <0
                    }
                    return Ok("Don't have money");
                }

            }
            return BadRequest();

        }
       

    }
}
