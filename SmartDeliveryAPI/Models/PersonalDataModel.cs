using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartDeliveryAPI.Models
{
    public class PersonalDataModel
    {
        public int data_ID { get; set; }
        public string p_name { get; set; }
        public string p_surname { get; set; }
        public string p_secondname { get; set; }
        public DateTime birth_date { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
    }
}