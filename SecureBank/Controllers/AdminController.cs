using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using SecureBank.Models;


namespace SecureBank.Controllers
{
    public class AdminController : ApiController
    {
        ProjectBankingEntities db = new ProjectBankingEntities();
        Enotification enotification = new Enotification();

        public IHttpActionResult getPendingApprovals()
        {
            var res = db.sp_pendingapprovals().ToList();

            return Ok(res);
        }



        [HttpPost]
        public HttpResponseMessage Adminapproval([FromBody] Approval app)
        {
            //if (app.IsApproved == false)
            try
            {
                var entity = db.Customers.FirstOrDefault(c => c.CID == app.CID);

                entity.IsApproved = app.IsApproved;
                db.SaveChanges();
                enotification.Notify(app);
            }

            catch (Exception ex)
            {
                // Console.WriteLine("Please try again");
                throw new Exception("Please try again" + ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK);

            //return Request.CreateResponse(HttpStatusCode.OK, entity);
            // return Request.CreateResponse(HttpStatusCode.OK);

        }
        
        
       

    }
}
