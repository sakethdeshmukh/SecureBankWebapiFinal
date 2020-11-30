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
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.AccountDetails = new HashSet<AccountDetail>();
            this.OccupationDetails = new HashSet<OccupationDetail>();
            this.PermanentAddresses = new HashSet<PermanentAddress>();
            this.ResidentialAddresses = new HashSet<ResidentialAddress>();
            this.StatusTrackings = new HashSet<StatusTracking>();
        }

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
        public Nullable<long> Aadharnumber { get; set; }
        [DataMember]
        public Nullable<System.DateTime> DOB { get; set; }
        [DataMember]
        public Nullable<bool> NetBankingOpted { get; set; }
        [DataMember]
        public Nullable<bool> DebitCardOpted { get; set; }
        [DataMember]
        public Nullable<bool> IsApproved { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccountDetail> AccountDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OccupationDetail> OccupationDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PermanentAddress> PermanentAddresses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResidentialAddress> ResidentialAddresses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StatusTracking> StatusTrackings { get; set; }
    }
}