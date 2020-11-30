using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SecureBank.Models;

namespace SecureBank.Controllers
{
    public class TransactionSuccessfulController : ApiController
    {
        ProjectBankingEntities db = new ProjectBankingEntities();
        [HttpGet]
        [Route("api/transuccess")]
        public IHttpActionResult transfersuccessful(int TransactionID)
        {
            var trans = db.sp_Transfer_successsful(TransactionID);
            return Ok(trans);

        }
    }
}
