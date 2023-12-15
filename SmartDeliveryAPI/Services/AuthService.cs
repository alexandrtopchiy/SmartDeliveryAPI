using SmartDeliveryAPI.Interfaces;
using SmartDeliveryAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace SmartDeliveryAPI.Services
{
    public class AuthService : IAuthService
    {

        SmartDeliveryEntities1 db = new SmartDeliveryEntities1();
        public ICollection<AuthModel> GetClientToken(string login, string password)
        {      
            try
            {
                var res = db.Auth.Where(x =>
                           login == x.c_login &
                           password == x.c_password).First();

                Collection<AuthModel> cl = new Collection<AuthModel>();

                cl.Add(new AuthModel { client_ID = (int)res.client_ID });

                return cl;
            }
            catch (Exception)
            {

                return null;
            }

        }
    }
}