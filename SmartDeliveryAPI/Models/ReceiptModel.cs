using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartDeliveryAPI.Models
{
    public class ReceiptModel
    {
        public int receipt_ID { get; set; }
        public string payment_status { get; set; }
        public string payment_method { get; set; }
        public int delivery_price { get; set; }
        public int package_price { get; set; }
    }
}