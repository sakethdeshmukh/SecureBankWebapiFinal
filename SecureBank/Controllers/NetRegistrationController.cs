using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SecureBank.Models;

namespace SecureBank.Controllers
{
    public class NetRegistrationController : ApiController
    {
        ProjectBankingEntities db = new ProjectBankingEntities();
        [HttpPost]
        public dynamic RegisterOnlineBanking(NetRegistration netRegistration)
        {
            if(db.AccountDetails.Any(a=>a.AccountNumber==netRegistration.AccountNumber))
            {
                var reg = db.sp_registeruser(netRegistration.AccountNumber, netRegistration.Password, netRegistration.TransactionPassword);
                db.SaveChanges();
                
            }
            else
            {
                return "Account Number does not exists";

            }
            return Request.CreateResponse(HttpStatusCode.OK, "Registered Successfully");

            //try
            //{
            //    var reg = db.sp_registeruser(netRegistration.AccountNumber, netRegistration.Password, netRegistration.TransactionPassword);
            //    db.SaveChanges();
            //    return Ok("Registered Successfully");
            //}
            //catch(Exception ex)
            //{
            //    throw new Exception("Account Number does not exist!!",ex);
            //}
        }
    }
}
