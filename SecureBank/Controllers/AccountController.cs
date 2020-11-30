using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SecureBank.Models;

namespace SecureBank.Controllers
{
    public class AccountController : ApiController
    {
        ProjectBankingEntities db = new ProjectBankingEntities();
        AccountClass objacc = new AccountClass();

        [Route("api/account")]
        public IHttpActionResult GetAccountById(int cid)
        {
            var res = objacc.Get(cid);

            return Ok(res);
        }


        public AccountDetail GetAccountById(long acc)
        {
            var res = objacc.GetByAccountNumber(acc);

            return res;
        }
    }
}
