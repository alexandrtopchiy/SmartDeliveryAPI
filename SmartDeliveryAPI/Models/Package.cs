//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartDeliveryAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Package
    {
        public int package_ID { get; set; }
        public string delivery_type { get; set; }
        public Nullable<int> package_data_ID { get; set; }
        public Nullable<int> receipt_ID { get; set; }
        public Nullable<int> client_ID { get; set; }
        public Nullable<int> department_ID { get; set; }
        public Nullable<int> courier_ID { get; set; }
        public Nullable<int> sender_ID { get; set; }
        public ICollection<Package_Data> Pd { get; } = new List<Package_Data>();
        public ICollection<Sender> Sn { get; } = new List<Sender>();

        public virtual Client Client { get; set; }
        public virtual Courier Courier { get; set; }
        public virtual Department Department { get; set; }
        public virtual Package_Data Package_Data { get; set; }
        public virtual Receipt Receipt { get; set; }
        public virtual Sender Sender { get; set; }
    }
}
