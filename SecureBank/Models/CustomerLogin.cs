using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SecureBank.Models;
using System.Runtime.Serialization;

namespace SecureBank.Models
{
    public class CustomerLogin
    {
        ProjectBankingEntities db = new ProjectBankingEntities();

        public AccountDetail VerifyLogin(int cid, string password)
        {
            AccountDetail accountDetail = null;

            try
            {
                var acc = db.AccountDetails
                    .Where(c => c.CID == cid && c.Password == password).FirstOrDefault();

                if (acc != null)
                {
                    accountDetail = acc;
                }

                else
                {
                    acc = null;
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return accountDetail;

        }
    }
}