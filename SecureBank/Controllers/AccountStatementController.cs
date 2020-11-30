using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SecureBank.Models;

namespace SecureBank.Controllers
{
    public class AccountStatementController : ApiController
    {
        ProjectBankingEntities db = new ProjectBankingEntities();

        //to get account statement between two dates
        [HttpGet]
        [Route("api/accountstatement")]
        public IHttpActionResult accstatement(DateTime begindate, DateTime enddate,long AccountNumber)
        {
            var acc = db.sp_accstatement_between_twodates(begindate, enddate, AccountNumber);
            return Ok(acc);
        }
    }
}
