using SmartDeliveryAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Http;
using System.Web.Mvc;
using SmartDeliveryAPI.Services;

namespace SmartDeliveryAPI.Controllers
{
    public class ProfileController : ApiController
    {
        SmartDeliveryEntities1 db = new SmartDeliveryEntities1();
        SmartDeliveryAPI.Services.ProfileService serv = new SmartDeliveryAPI.Services.ProfileService();
    
        
        // GET: Profile
        [System.Web.Http.HttpGet]
        [System.Web.Mvc.ActionName("GetClientProfile")]
        public IHttpActionResult GetClientProfile (int token)
        {
            
            return Ok(serv.GetClientProfile(token));
        }


        // GET: Personal data
        [System.Web.Http.HttpGet]
        [System.Web.Mvc.ActionName("GetPersonalData")]
        public IHttpActionResult GetPersonalData(int data_ID)
        {

            return Ok(serv.GetPersonalData(data_ID));
        }


        // GET: Bank Card data
        [System.Web.Http.HttpGet]
        [System.Web.Mvc.ActionName("GetCardData")]
        public IHttpActionResult GetCardData(int card_ID)
        {

            return Ok(serv.GetCardData(card_ID));
        }

        // POST: Update profile
        [System.Web.Http.HttpPost]
        [System.Web.Mvc.ActionName("UpdateMyProfile")]
        public IHttpActionResult UpdateMyProfile(PersonalDataModel pd)
        {

            return Ok(serv.UpdateMyProfile(pd));
        }

        // POST: Update card data
        [System.Web.Http.HttpPost]
        [System.Web.Mvc.ActionName("UpdateBankCard")]
        public IHttpActionResult UpdateBankCard(CardDataModel pd)
        {

            return Ok(serv.UpdateBankCard(pd));
        }

    }
}