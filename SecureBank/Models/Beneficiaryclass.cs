using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SecureBank.Models;

namespace SecureBank.Models
{
    public class Beneficiaryclass
    {
        ProjectBankingEntities db = new ProjectBankingEntities();

        public void AddBenificiary(long id, BeneficiaryDetail newben)
        {
            db.BeneficiaryDetails.Add(newben);
            db.SaveChanges();

        }

        public BeneficiaryDetail Get(long cusacc, long benacc)
        {
            var bene = db.BeneficiaryDetails
                .Where(b => b.AccountNumber == cusacc && b.BenificiaryAccountNumber == benacc).FirstOrDefault();
            return bene;
        }

        public void DeleteBeneficiary(long custacc, long beneacc)
        {
            var res = db.BeneficiaryDetails
                .Where(b => b.AccountNumber == custacc && b.BenificiaryAccountNumber == beneacc).FirstOrDefault();
            db.BeneficiaryDetails.Remove(res);

            db.SaveChanges();

        }


        public dynamic ViewAllBeneficiaries(long cusacc)
        {
            var res = db.BeneficiaryDetails
                .Where(b => b.AccountNumber == cusacc).ToList();

            return res;
        }
    }
}