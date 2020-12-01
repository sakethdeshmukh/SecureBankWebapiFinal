using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecureBank.Models
{
    public class AccountClass
    {
        ProjectBankingEntities db = new ProjectBankingEntities();


        public IEnumerable<AccountDetail> Get(int id)
        {
            var acc = db.AccountDetails
                .Where(a => a.CID == id);

            return acc;

        }

        public AccountDetail GetByAccountNumber(long id)
        {
            var acc = db.AccountDetails.Find(id);

            return acc;
        }
    }
}