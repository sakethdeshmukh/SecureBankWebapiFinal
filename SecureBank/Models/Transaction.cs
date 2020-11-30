using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecureBank.Models
{
    public class Transaction
    {
        private string err = "Insufficient Funds to carry out this trasaction";
        ProjectBankingEntities db = new ProjectBankingEntities();

        public void Add(TransactionDetail transactionDetail)
        {
            db.TransactionDetails.Add(transactionDetail);
            db.SaveChanges();
        }


        public dynamic Viewall(long accnum)
        {
            var trans = (from t in db.TransactionDetails
                         where (t.SenderAccount == accnum || t.RecieverAccount == accnum)
                         select t).ToList();
            return trans;

        }

        public dynamic GetBetweenDates(DateTime? startDate, DateTime? endDate, long id)
        {
            var trans = (from t in db.TransactionDetails
                         where ((t.SenderAccount == id && (t.TransactionDate >= startDate && t.TransactionDate <= endDate)) || (t.RecieverAccount == id && (t.TransactionDate >= startDate && t.TransactionDate <= endDate)))
                         orderby t.TransactionDate descending
                         select t).ToList();

            return trans;
        }

        public dynamic UpdateBalance(TransactionDetail transactionDetail)
        {
            var sendacc = db.AccountDetails.Where(accnum => accnum.AccountNumber == transactionDetail.SenderAccount).FirstOrDefault();
            var receacc = db.AccountDetails.Where(accnum => accnum.AccountNumber == transactionDetail.RecieverAccount).FirstOrDefault();

            if (sendacc.AccountBalance >= transactionDetail.TransactionAmount)
            {
                sendacc.AccountBalance -= transactionDetail.TransactionAmount;
                receacc.AccountBalance += transactionDetail.TransactionAmount;
                db.SaveChanges();

            }
            else
            {


                return err;
            }

            var transid = (from t in db.TransactionDetails
                           orderby t.TransactionID descending
                           select t.TransactionID).FirstOrDefault();

            return transid;
        }

        public IEnumerable<TransactionDetail> GetRecentTransaction(long id)
        {
            var res = (from t in db.TransactionDetails
                       where (t.SenderAccount == id || t.RecieverAccount == id)
                       orderby t.TransactionID descending
                       select t).Take(10).ToList();

            return res;

        }
    }
}