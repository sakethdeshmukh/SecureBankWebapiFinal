using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SecureBank.Models
{
    [DataContract]
    public class MailClass
    {
        [DataMember]
        public string subject { get; set; }
        [DataMember]
        public string message { get; set; }
    }
}