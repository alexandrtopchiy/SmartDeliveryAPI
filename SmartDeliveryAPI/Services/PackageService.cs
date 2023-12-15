using SmartDeliveryAPI.Interfaces;
using SmartDeliveryAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace SmartDeliveryAPI.Services
{
    public class PackageService: IPackageService
    {
        SmartDeliveryEntities1 db = new SmartDeliveryEntities1();
        
        public List<PackageModel> GetPackageInfo(int client_ID, string status)
        {
            
            try
            {
                var res = (from p in db.Package
                           join c in db.Client on p.client_ID equals c.client_ID
                           join d in db.Department on p.department_ID equals d.department_ID
                           join pd in db.Package_Data on p.package_data_ID equals pd.package_data_ID
                           join r in db.Receipt on p.receipt_ID equals r.receipt_ID
                          // join cr in db.Courier on p.courier_ID equals cr.courier_ID
                           join s in db.Sender on p.sender_ID equals s.sender_ID
                           where p.client_ID == client_ID
                           where pd.package_status == status
                           select new PackageModel
                           {
                               package_ID = p.package_ID,
                               delivery_type = p.delivery_type,
                               courier_ID = p.courier_ID.Value,
                               package_data_ID = p.package_data_ID.Value,
                               receipt_ID = p.receipt_ID.Value,
                               sender_ID = p.sender_ID.Value,   
                               department_ID = p.department_ID.Value,
                               client_ID = p.client_ID.Value,

                               Package_Data = new PackageDataModel
                               {
                                   package_status = pd.package_status,
                                   send_date = pd.send_date.Value,
                                   arrival_date = pd.arrival_date.Value,
                                   descript = pd.descript,
                                   weights = pd.weights.Value,
                                   volume = pd.volume.Value
                               },
                               Receipt = new ReceiptModel
                               {
                                   payment_status = r.payment_status,
                                   payment_method = r.payment_method,
                                   delivery_price = r.delivery_price.Value,
                                   package_price = r.package_price.Value
                               },
                               Department = new DepartmentModel
                               {
                                   department_ID = d.department_ID,
                                   department_status = d.department_status,
                                   adress = d.adress,
                                   city = d.city,
                                   work_time = d.work_time
                               },
                               Sender = new SenderModel
                               {
                                   sender_ID = s.sender_ID,
                                   data_ID = s.data_ID.Value
                               }
                           }).ToList();
            return res;

            }
            catch (Exception)
            {

                 return null;
            }

        }


        public IEnumerable<CourierModel> GetCourierInfo(int courier_ID)
        {
            try
            {
                var res = (from c in db.Courier
                           join pers in db.Personal_Data on c.data_ID equals pers.data_ID
                           where c.courier_ID == courier_ID
                           select new CourierModel
                           {
                               courier_ID = c.courier_ID,
                               rating = c.rating.Value,
                               Personal_Data = new PersonalDataModel
                               {
                                   p_name = pers.p_name,
                                   p_surname = pers.p_surname,
                                   p_secondname = pers.p_secondname,
                                   birth_date = pers.birth_date.Value,
                                   email = pers.email,
                                   phone_number = pers.phone_number
                               }
                           });
                return res;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public IEnumerable<SenderModel> GetSenderInfo(int sender_ID)
        {
            try
            {
                var res = (from s in db.Sender
                           join pers in db.Personal_Data on s.data_ID equals pers.data_ID
                           where s.sender_ID == sender_ID
                           select new SenderModel
                           {
                               sender_ID = s.sender_ID,
                               data_ID = s.data_ID.Value,
                               Personal_Data = new PersonalDataModel
                               {
                                   p_name = pers.p_name,
                                   p_surname = pers.p_surname,
                                   p_secondname = pers.p_secondname,
                                   birth_date = pers.birth_date.Value,
                                   email = pers.email,
                                   phone_number = pers.phone_number
                               }
                           });
                return res;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Receipt PayForPackage(int receipt_ID)    
        {
            try
            {
                var rec = db.Receipt.Where(x => x.receipt_ID == receipt_ID).First();
                rec.payment_status = "Payed";
                rec.payment_method = "Card";
                db.SaveChanges();
                return rec;
            }
            catch (Exception)
            {
                return null; ;
            }  
            
        }

        public List<DepartmentModel> GetAvaliableDepartmentsList()
        {
            try
            {
                var res = (from d in db.Department
                           select new DepartmentModel
                           {
                               department_ID = d.department_ID,
                               department_status = d.department_status,
                               adress = d.adress,
                               city = d.city,
                               indx = d.indx,   
                               work_time = d.work_time,
                               phone_number=d.phone_number
                           }
                           ).ToList();
                return res;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public List<int> GetPackageDataReceiptPackageMaxID()
        {
            try
            {
                int r1 = db.Package_Data.Max(u => u.package_data_ID);
                int r2 = db.Receipt.Max(u => u.receipt_ID);
                int r3 = db.Package.Max(u => u.package_ID);

                List<int> res = new List<int>();
                res.Add(r1);
                res.Add(r2);
                res.Add(r3);

                return res;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public string AddNewPackage(PackageModel pd)
        {
            try
            {
                Package pack = new Package()
                {
                    package_data_ID = pd.package_data_ID,
                    delivery_type = pd.delivery_type,
                    package_ID = pd.package_ID,
                    receipt_ID = pd.receipt_ID,
                    client_ID = pd.client_ID,
                    department_ID = pd.department_ID,
                    sender_ID = pd.sender_ID
                };

                db.Package.Add(pack);
                db.SaveChanges();
                return "Success";
            }
            catch (Exception)
            {
                return "Error";
            }

        }

        public string AddNewPackageData(PackageDataModel pdModel)
        {
            try
            {
                Package_Data pack = new Package_Data()
                {
                    package_data_ID=pdModel.package_data_ID,
                    send_date = pdModel.send_date,
                    arrival_date = pdModel.arrival_date,
                    receive_date = pdModel.receive_date,
                    package_status = pdModel.package_status,
                    descript = pdModel.descript,
                    weights = pdModel.weights,
                    volume = pdModel.volume
                };

                db.Package_Data.Add(pack);
                db.SaveChanges();
                return "Success";
            }
            catch (Exception)
            {
                return "Error";
            }


        }

        public string AddNewReceiptData(ReceiptModel rec)
        {
            try
            {
                Receipt pack = new Receipt()
                {
                   receipt_ID = rec.receipt_ID,
                   payment_status = rec.payment_status,
                   payment_method = rec.payment_method,
                   delivery_price = rec.delivery_price,
                   package_price = rec.package_price
                };

                db.Receipt.Add(pack);
                db.SaveChanges();
                return "Success";
            }
            catch (Exception)
            {
                return "Error";
            }

        }
    }
}