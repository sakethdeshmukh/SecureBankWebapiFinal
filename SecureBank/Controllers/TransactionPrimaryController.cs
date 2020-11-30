using SecureBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SecureBank.Controllers
{
    public class TransactionPrimaryController : ApiController
    {
        ProjectBankingEntities db = new ProjectBankingEntities();
        Transaction objtrans = new Transaction();


        [HttpPost]
        
        public IHttpActionResult AddTransaction([FromBody] TransactionDetail transactionDetail)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);

                }
                else
                {
                    objtrans.Add(transactionDetail);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            dynamic result = objtrans.UpdateBalance(transactionDetail);

            return Ok(result);
        }

        //[HttpGet]
        //public /*dynamic*/  IHttpActionResult StatementBetweenDate(DateTime? startDate, DateTime? endDate, long id)
        //{
        //    try
        //    {
        //        var state = objtrans.GetBetweenDates(startDate, endDate, id);
        //        return Ok(state);
        //    }

        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //}
    }
}
