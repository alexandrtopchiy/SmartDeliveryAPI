using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartDeliveryAPI.Models
{
    public class PackageModel
    {
        public int package_ID { get; set; }
        public string delivery_type { get; set; }
        public int package_data_ID { get; set; }
        public int receipt_ID { get; set; }
        public int client_ID { get; set; }
        public int department_ID { get; set; }
        public Nullable<int> courier_ID { get; set; }
        public int sender_ID { get; set; }

        public virtual CourierModel Courier { get; set; }
        public virtual DepartmentModel Department{ get; set; }
        public virtual PackageDataModel Package_Data { get; set; }
        public virtual ReceiptModel Receipt { get; set; }
        public virtual SenderModel Sender { get; set; }
    }
}