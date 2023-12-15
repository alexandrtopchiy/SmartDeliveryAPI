using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartDeliveryAPI.Models
{
    public class SenderModel
    {
        public int sender_ID { get; set; }
        public int data_ID { get; set; }

       public virtual PersonalDataModel Personal_Data { get; set; }   

    }
}