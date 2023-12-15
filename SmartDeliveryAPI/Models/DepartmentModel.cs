using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartDeliveryAPI.Models
{
    public class DepartmentModel
    {
        public int department_ID { get; set; }
        public string department_status { get; set; }
        public string adress { get; set; }
        public string city { get; set; }
        public string indx { get; set; }
        public string work_time { get; set; }
        public string phone_number { get; set; }
    }
}