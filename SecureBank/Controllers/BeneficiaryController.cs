using SecureBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SecureBank.Controllers
{
    public class BeneficiaryController : ApiController
    {
        ProjectBankingEntities db = new ProjectBankingEntities();
        Beneficiaryclass objben = new Beneficiaryclass();

        [HttpPost]
        [Route("api/Beneficiary/{id}")]
        
        public IHttpActionResult PostBeneficiary(long id, [FromBody] BeneficiaryDetail beny)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                objben.AddBenificiary(id, beny);
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(beny);
        }

        [HttpDelete]

        public HttpResponseMessage DelBeneficiary(long cusacc, long benacc)
        {
            try
            {
                BeneficiaryDetail beneficiaryDetail = objben.Get(cusacc, benacc);

                if (beneficiaryDetail == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "No Beneficiary Found");
                }

                objben.DeleteBeneficiary(cusacc, benacc);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return Request.CreateResponse(HttpStatusCode.OK, "Beneficiary Deleted");
        }



        [HttpGet]
        [Route("api/AllBeneficiaries")]

        public dynamic GetAllBeneficiaries(long Cusacc)
        {
            try
            {
                var benlist = objben.ViewAllBeneficiaries(Cusacc);
                return Ok(benlist);

            }
            catch (Exception ex)

            {
                throw new Exception(ex.Message);
            }


        }



    }
}
