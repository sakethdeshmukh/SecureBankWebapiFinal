using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SecureBank.Models;

namespace SecureBank.Controllers
{
    public class CustomerLoginController : ApiController
    {
        ProjectBankingEntities db = new ProjectBankingEntities();
        CustomerLogin objcuslogin = new CustomerLogin();

        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage VerifyLogin(Login login)
        {
            AccountDetail accountDetail;
            try
            {
                accountDetail = objcuslogin.VerifyLogin(login.CID, login.Password);
                if (accountDetail == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Credentials");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Request.CreateResponse(HttpStatusCode.OK, accountDetail);

        }
    }
}
