using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartDeliveryAPI.Models
{
    public class CourierModel
    {
        public int courier_ID { get; set; }
        public int data_ID { get; set; }
        public int rating { get; set; }
        public virtual PersonalDataModel Personal_Data { get; set; }
    }
}