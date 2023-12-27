using SmartDeliveryAPI.Models;
using SmartDeliveryAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SmartDeliveryAPI.Controllers
{
    public class PackageController : ApiController
    {

        PackageService serv = new PackageService();


        // GET: ActivePackageInfo
        [System.Web.Http.HttpGet]
        [System.Web.Mvc.ActionName("GetPackageInfo")]
        public IHttpActionResult GetPackageInfo(int client_ID, string status)
        {

            return Ok(serv.GetPackageInfo(client_ID,status));
        }


        [System.Web.Http.HttpGet]
        [System.Web.Mvc.ActionName("GetAvaliableDepartmentsList")]
        public IHttpActionResult GetAvaliableDepartmentsList()
        {

            return Ok(serv.GetAvaliableDepartmentsList());
        }

        [System.Web.Http.HttpGet]
        [System.Web.Mvc.ActionName("GetPackageDataReceiptPackageSenderPersonalMaxID")]
        public IHttpActionResult GetPackageDataReceiptPackageSenderPersonalMaxID()
        {

            return Ok(serv.GetPackageDataReceiptPackageSenderPersonalMaxID());
        }

        [System.Web.Http.HttpGet]
        [System.Web.Mvc.ActionName("GetCourierInfo")]
        public IHttpActionResult GetCourierInfo(int courier_ID)
        {

            return Ok(serv.GetCourierInfo(courier_ID));
        }

        [System.Web.Http.HttpGet]
        [System.Web.Mvc.ActionName("GetSenderInfo")]
        public IHttpActionResult GetSenderInfo(int sender_ID)
        {

            return Ok(serv.GetSenderInfo(sender_ID));
        }

        //UPDATE

        [System.Web.Http.HttpPost]
        [System.Web.Mvc.ActionName("PayForPackage")]
        public IHttpActionResult PayForPackage(int receipt_ID)
        {

            return Ok(serv.PayForPackage(receipt_ID));
        }
       
        [System.Web.Http.HttpPost]
        [System.Web.Mvc.ActionName("RequestCourier")]
        public IHttpActionResult RequestCourier(int package_ID, int courier_ID, string adress)
        {

            return Ok(serv.RequestCourier(package_ID, courier_ID, adress));
        }

        //  ADD INFO
        [System.Web.Http.HttpPost]
        [System.Web.Mvc.ActionName("AddNewPackage")]
        public IHttpActionResult AddNewPackage(PackageModel pd)
        {

            return Ok(serv.AddNewPackage(pd));
        }

        [System.Web.Http.HttpPost]
        [System.Web.Mvc.ActionName("AddNewPackageData")]
        public IHttpActionResult AddNewPackageData(PackageDataModel pd)
        {

            return Ok(serv.AddNewPackageData(pd));
        }

        [System.Web.Http.HttpPost]
        [System.Web.Mvc.ActionName("AddNewReceiptData")]
        public IHttpActionResult AddNewReceiptData(ReceiptModel pd)
        {

            return Ok(serv.AddNewReceiptData(pd));
        }

        [System.Web.Http.HttpPost]
        [System.Web.Mvc.ActionName("AddNewSenderData")]
        public IHttpActionResult AddNewSenderData(SenderModel pd)
        {
            return Ok(serv.AddNewSenderData(pd));
        }


        [System.Web.Http.HttpPost]
        [System.Web.Mvc.ActionName("AddNewPersonalData")]
        public IHttpActionResult AddNewPersonalData(PersonalDataModel pd)
        {
            return Ok(serv.AddNewPersonalData(pd));
        }
    }
}