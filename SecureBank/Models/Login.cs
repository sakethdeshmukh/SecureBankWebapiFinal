using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SecureBank.Models
{
    [DataContract]
    public class Login
    {
        [DataMember]
        public int CID { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}