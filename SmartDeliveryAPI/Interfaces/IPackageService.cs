using SmartDeliveryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDeliveryAPI.Interfaces
{
    internal interface IPackageService
    {

        List<PackageModel> GetPackageInfo(int client_ID, string status);

        IEnumerable<CourierModel> GetCourierInfo(int courier_ID);
        IEnumerable<SenderModel> GetSenderInfo(int sender_ID);

        Receipt PayForPackage(int receipt_ID);

        List<DepartmentModel> GetAvaliableDepartmentsList();
        string AddNewPackage(PackageModel pd);
        string AddNewPackageData(PackageDataModel pdModel);
        string AddNewReceiptData(ReceiptModel rec);


    }
}
