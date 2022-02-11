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
                return Ok(db.account.FirstOrDefault(a => a.id == id));
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
                foreach (var l in db.account.ToList())
                {
                    if (l.email == login.Email && l.password == login.Password)
                    {
                        l.password = login.Name;
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
                foreach (var l in db.account.ToList())
                {
                    if (l.email == loginE.Email && l.password == loginE.Password)
                    {
                        l.email = loginE.NewEmail;
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
                foreach (var l in db.account.ToList())
                {
                    if (l.email == login.Email && l.password == login.Password)
                    {
                        l.name = login.Name;
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
        public IActionResult ChangeMoneyMul([FromBody] List<OperationCout> model)
        {
            using ApplicationContext db = new ApplicationContext();
            {
                foreach (var l in db.account.ToList())
                {
                    foreach (var item in model)
                    {


                        if (l.id == item.userid)
                        {
                            l.money = l.money + item.price;
                            db.SaveChanges();
                            return Ok(l);
                            //тестиииить
                        }
                    }

                }

            }
            return BadRequest();

        }

        [Route("minusmoney")]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult ChangeMoneyMin([FromBody]OperationCout model)
        {
            using ApplicationContext db = new ApplicationContext();
            {
                foreach (var l in db.account.ToList())
                {
                    if (l.id== model.userid && l.money > model.price)
                    {
                        l.money = l.money - model.price;
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
