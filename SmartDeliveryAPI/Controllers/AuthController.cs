
using SmartDeliveryAPI.Models;
using SmartDeliveryAPI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SmartDeliveryAPI.Controllers
{
    public class AuthController : ApiController
    {

        AuthService serv = new AuthService();

        [System.Web.Http.HttpGet]
        [System.Web.Mvc.ActionName("GetClientToken")]
        public IHttpActionResult GetClientToken(string login, string password)
        {

            return Ok(serv.GetClientToken(login, password));
        }
    }
}