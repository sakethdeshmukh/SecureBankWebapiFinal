using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SecureBank.Models
{
    [DataContract]
    public class Adminlogin
    {
        [DataMember]
        public int AdminId { get; set; }
        [DataMember]
        public string AdminPassword { get; set; }

    }
}