using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartDeliveryAPI.Models
{
    public class CardDataModel
    {
        public int card_ID { get; set; }
        public string card_number { get; set; }
        public DateTime expiring_date { get; set; }
        public int cvv { get; set; }
        public string bank_name { get; set; }
    }
}