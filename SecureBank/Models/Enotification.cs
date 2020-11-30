using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SecureBank.Models;
using System.Data.Entity;
using System.Net.Mail;
using System.Text;

namespace SecureBank.Models
{
    public class Enotification
    {
        ProjectBankingEntities db = new ProjectBankingEntities();

        public void Notify(Approval nota)
        {
            /// db.Entry(nota).State = EntityState.Modified;
            db.SaveChanges();

            if (nota.IsApproved == true)
            {
                var cus = db.Customers
                          .Where(u => u.CID == nota.CID).FirstOrDefault();



                StringBuilder builder = new StringBuilder();
                Random random = new Random();
                char ch;
                for (int i = 0; i < 8; i++)
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                    builder.Append(ch);
                }

                var pass = builder.ToString();

                StringBuilder build = new StringBuilder();
                Random rand = new Random();
                char c;
                for (int i = 0; i < 8; i++)
                {
                    c = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                    build.Append(c);
                }
                var tpass = build.ToString();

                AccountDetail acc = new AccountDetail();
                acc.CID = cus.CID;
                acc.Password = pass;
                acc.TransactionPassword = tpass;
                db.AccountDetails.Add(acc);
                db.SaveChanges();


                // acc.CID = cus.CID;
                // acc.TransactionPassword = tpass;
                //// db.AccountDetails.Add(acc)

                var cust = db.AccountDetails
                        .Where(u => u.CID == nota.CID).FirstOrDefault();
                MailClass mail = new MailClass();
                mail.subject = "Account Approved";
                mail.message = "Congratulations! Your account has been approved.\nUse these credentials to login into your account.\n" + "CID : " + cus.CID + "\n" + "Account Number: " + cust.AccountNumber + "Login Password : " + pass + "Transaction Password :  " + tpass;
                string res = PostSendEmail(cus, mail);
            }
            else
            {
                var cus = db.Customers
                          .Where(u => u.CID == nota.CID).FirstOrDefault();
                MailClass mail1 = new MailClass();
                mail1.subject = "Account Disapproved";
                mail1.message = "Sorry! your account is not approved due to invalid details provided in the opening form";
                string res = PostSendEmail(cus, mail1);
            }
        }


        public string PostSendEmail(Customer cust, MailClass mail)
        {
            SmtpClient client = new SmtpClient();
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("securebankingteam@gmail.com");
            msg.To.Add(new MailAddress(cust.EmailID));
            msg.Subject = mail.subject;
            msg.IsBodyHtml = true;
            msg.Body = mail.message;
            try
            {
                client.Send(msg);
                return "OK";
            }
            catch (Exception ex)
            {
                return "error:" + ex.ToString();
            }
        }




    }
}