using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SecureBank.Models;

namespace SecureBank.Controllers
{
    public class ApprovalController : ApiController
    {
        ProjectBankingEntities db = new ProjectBankingEntities();
        [HttpGet]
        public IHttpActionResult Approvals()
        {
            var res = db.sp_viewapprovals().ToList();

            return Ok(res);
        }
    }
}
