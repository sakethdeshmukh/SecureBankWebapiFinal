//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SecureBank.Models
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class BeneficiaryDetail
    {
        [DataMember]
        public int Bid { get; set; }
        [DataMember]
        public Nullable<long> AccountNumber { get; set; }
        [DataMember]
        public string BeneficiaryName { get; set; }
        [DataMember]
        public Nullable<long> BenificiaryAccountNumber { get; set; }
    
        public virtual AccountDetail AccountDetail { get; set; }
    }
}
