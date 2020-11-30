using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SecureBank.Models;

namespace SecureBank.Controllers
{
    public class TransactionDetailsController : ApiController
    {
        private ProjectBankingEntities db = new ProjectBankingEntities();

        // GET: api/TransactionDetails
        public IQueryable<TransactionDetail> GetTransactionDetails()
        {
            return db.TransactionDetails;
        }

        // GET: api/TransactionDetails/5
        [ResponseType(typeof(TransactionDetail))]
        public IHttpActionResult GetTransactionDetail(int id)
        {
            TransactionDetail transactionDetail = db.TransactionDetails.Find(id);
            if (transactionDetail == null)
            {
                return NotFound();
            }

            return Ok(transactionDetail);
        }

        // PUT: api/TransactionDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTransactionDetail(int id, TransactionDetail transactionDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transactionDetail.TransactionID)
            {
                return BadRequest();
            }

            db.Entry(transactionDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TransactionDetails
        [ResponseType(typeof(TransactionDetail))]
        public IHttpActionResult PostTransactionDetail(TransactionDetail transactionDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TransactionDetails.Add(transactionDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = transactionDetail.TransactionID }, transactionDetail);
        }

        // DELETE: api/TransactionDetails/5
        [ResponseType(typeof(TransactionDetail))]
        public IHttpActionResult DeleteTransactionDetail(int id)
        {
            TransactionDetail transactionDetail = db.TransactionDetails.Find(id);
            if (transactionDetail == null)
            {
                return NotFound();
            }

            db.TransactionDetails.Remove(transactionDetail);
            db.SaveChanges();

            return Ok(transactionDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TransactionDetailExists(int id)
        {
            return db.TransactionDetails.Count(e => e.TransactionID == id) > 0;
        }
    }
}