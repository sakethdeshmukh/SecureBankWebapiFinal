using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SecureBank.Models
{
    [DataContract]
    public class NetRegistration
    {
        [DataMember]
        public long AccountNumber { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string TransactionPassword { get; set; }
    }
}