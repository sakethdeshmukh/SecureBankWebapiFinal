using SecureBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SecureBank.Controllers
{
    public class AccountOpeningController : ApiController
    {
        ProjectBankingEntities db = new ProjectBankingEntities();

        [HttpPost]

        public dynamic Openingaccount(AccountOpening accopen)
        {
            Customer cus = new Customer();

            List<AccountOpening> objacc = new List<AccountOpening>();
            if (db.Customers.Any(o => o.Aadharnumber == accopen.Aadharnumber))
            {
                return "Adhar Number Already Exists";
            }
            else
            {

                cus.FirstName = accopen.FirstName;
                cus.LastName = accopen.LastName;
                cus.MiddleName = accopen.MiddleName;
                cus.FatherName = accopen.FatherName;
                cus.MobileNumber = accopen.MobileNumber;
                cus.Aadharnumber = accopen.Aadharnumber;
                cus.EmailID = accopen.EmailID;
                cus.DOB = accopen.DOB;
                cus.NetBankingOpted = accopen.NetBankingOpted;
                cus.DebitCardOpted = accopen.DebitCardOpted;
                db.Customers.Add(cus);
                db.SaveChanges();

                var cust = (from c in db.Customers
                            where c.Aadharnumber == accopen.Aadharnumber
                            select c.CID).FirstOrDefault();

                int id = 0;
                if (cust != null)
                {
                    id = cust;
                }

                OccupationDetail occ = new OccupationDetail();
                occ.CID = id;
                occ.Occupationtype = accopen.Occupationtype;
                occ.SourceofIncome = accopen.SourceofIncome;
                occ.GrossannualIncome = accopen.GrossannualIncome;
                db.OccupationDetails.Add(occ);
                db.SaveChanges();

                ResidentialAddress res = new ResidentialAddress();
                res.CID = id;
                res.RAddressLine1 = accopen.RAddressLine1;
                res.RAddressLine2 = accopen.RAddressLine2;
                res.RLandmark = accopen.RLandmark;
                res.RPincode = accopen.RPincode;
                res.RState = accopen.RState;
                res.RCity = accopen.RCity;
                db.ResidentialAddresses.Add(res);
                db.SaveChanges();

                PermanentAddress perm = new PermanentAddress();
                perm.CID = id;
                perm.PAddressLine1 = accopen.PAddressLine1;

                perm.PAddressLine2 = accopen.PAddressLine2;
                perm.PLandmark = accopen.PLandmark;
                perm.PPincode = accopen.PPincode;
                perm.PState = accopen.PState;
                perm.PCity = accopen.PCity;
                db.PermanentAddresses.Add(perm);
                db.SaveChanges();
            }

            return Request.CreateResponse(HttpStatusCode.OK, "Added Successfully");


        }

        [HttpGet]
        [Route("api/userprofile")]
        public IHttpActionResult UserProfile(int id)
        {

            var res = db.sp_ViewCustomerDetails(id);

            return Ok(res);


        }



    }
}
