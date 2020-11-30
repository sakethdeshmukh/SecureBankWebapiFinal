using SecureBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SecureBank.Controllers
{
    public class TransactionController : ApiController
    {
        ProjectBankingEntities db = new ProjectBankingEntities();
        Transaction objtrans = new Transaction();


        [HttpGet]
        public /*IEnumerable<TransactionDetail>*/ IHttpActionResult GetTransactions(long id)
        {
            try
            {
                var trans = objtrans.Viewall(id);
                return Ok(trans);

            }

            catch (Exception ex)
            {
                throw new Exception("Account Number doesnot Exist" + ex.Message);
            }



        }

        //to get recent transactions
        [HttpGet]
        [Route("api/transactions")]

        public /*IEnumerable<TransactionDetail>*/ IHttpActionResult GetRecentTransactions(long id)
        {
            try
            {
                var trans = objtrans.GetRecentTransaction(id);
                return Ok(trans);

            }

            catch (Exception ex)
            {
                throw new Exception("Account Number doesnot Exist" + ex.Message);
            }

        }


    }
}
