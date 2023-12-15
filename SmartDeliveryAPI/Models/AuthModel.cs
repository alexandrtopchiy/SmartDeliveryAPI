using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartDeliveryAPI.Models
{
    public class AuthModel
    {
        public int auth_ID { get; set; }
        public string c_login { get; set; }
        public string c_password { get; set; }
        public int  client_ID { get; set; }
    }
}