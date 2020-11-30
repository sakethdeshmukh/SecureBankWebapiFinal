using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SecureBank.Models
{
    [DataContract]
    public class AccountOpening
    {
        [DataMember]
        public int CID { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string FatherName { get; set; }
        [DataMember]
        public string MobileNumber { get; set; }
        [DataMember]
        public string EmailID { get; set; }
        [DataMember]
        public long Aadharnumber { get; set; }
        [DataMember]
        public DateTime DOB { get; set; }
        [DataMember]
        public bool NetBankingOpted { get; set; }
        [DataMember]
        public bool DebitCardOpted { get; set; }
        [DataMember]
        public string Occupationtype { get; set; }
        [DataMember]
        public string SourceofIncome { get; set; }
        [DataMember]
        public double GrossannualIncome { get; set; }
        [DataMember]
        public string PAddressLine1 { get; set; }
        [DataMember]
        public string PAddressLine2 { get; set; }
        [DataMember]
        public string PLandmark { get; set; }
        [DataMember]
        public string PState { get; set; }
        [DataMember]
        public string PCity { get; set; }
        [DataMember]
        public string PPincode { get; set; }
        [DataMember]
        public string RAddressLine1 { get; set; }
        [DataMember]
        public string RAddressLine2 { get; set; }
        [DataMember]
        public string RLandmark { get; set; }
        [DataMember]
        public string RState { get; set; }
        [DataMember]
        public string RCity { get; set; }
        [DataMember]
        public string RPincode { get; set; }





    }
}