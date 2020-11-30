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
        public HttpResponseMessage RegisterOnlineBanking(NetRegistration netRegistration)
        {
            try
            {
                var reg = db.sp_registeruser(netRegistration.AccountNumber, netRegistration.Password, netRegistration.TransactionPassword);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, reg);
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Account Number doesnt exist");
            }
        }
    }
}
