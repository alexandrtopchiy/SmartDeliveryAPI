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
    
    public partial class Personal_Data
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personal_Data()
        {
            this.Client = new HashSet<Client>();
            this.Courier = new HashSet<Courier>();
            this.Sender = new HashSet<Sender>();
        }
    
        public int data_ID { get; set; }
        public string p_name { get; set; }
        public string p_surname { get; set; }
        public string p_secondname { get; set; }
        public Nullable<System.DateTime> birth_date { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Client> Client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Courier> Courier { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sender> Sender { get; set; }
    }
}
