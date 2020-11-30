using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SecureBank.Models;

namespace SecureBank.Controllers
{
    public class AdminLoginController : ApiController
    {
        ProjectBankingEntities db = new ProjectBankingEntities();
        [HttpGet]
        public IHttpActionResult Login(int AdminId, string AdminPassword)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var isValidUser = false;
            var user = db.Admins.Where(w => w.AdminId == AdminId && w.AdminPassword == AdminPassword).FirstOrDefault();
            if (user != null)
            
                isValidUser = true;
                //var model = new
                //{
                //    IsValidUser = isValidUser,
                //    AdminId = user != null ? user.AdminId : 0,
                //    message = "User LogedIn Successfully"
                //};
                //return Ok(model);
            
            
            
                var model = new
                {
                    IsValidUser = isValidUser,
                    AdminId = user != null ? user.AdminId : 0,
                    //message = "InValid Creditials"
                };
                return Ok(model);
                //var user =
            
            
            //db.Admins.Where(w => w.AdminId == AdminId && w.AdminPassword == AdminPassword).FirstOrDefault();
            //if (user != null)
            //{
            //    return Ok("Successful");
            //}
            //else
            //{
            //    return Ok("Invalid Credentials");
            //}

        }
    }
}
