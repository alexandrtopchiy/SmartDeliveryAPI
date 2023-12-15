using SmartDeliveryAPI.Interfaces;
using SmartDeliveryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SmartDeliveryAPI.Services
{
    public class ProfileService : IProfileService
    {
        SmartDeliveryEntities1 db = new SmartDeliveryEntities1();

        public IEnumerable<ProfileInfo> GetClientProfile(int token)
        {
            try
            {
                var result = (from cl in db.Client
                              join pers in db.Personal_Data on cl.data_ID equals pers.data_ID
                              where cl.client_ID == token
                              select new ProfileInfo
                              {
                                  client_ID = cl.client_ID,
                                  data_ID = cl.data_ID.Value,
                                  card_ID = cl.card_ID.Value,
                                  //city = cl.city,
                                  //adress = cl.adress,
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

                return result;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public IEnumerable<PersonalDataModel> GetPersonalData(int token)
        {
            try
            {
                var result = (from pers in db.Personal_Data 
                              where pers.data_ID == token
                              select new PersonalDataModel
                              {                      
                                  p_name = pers.p_name,
                                  p_surname = pers.p_surname,
                                  p_secondname = pers.p_secondname,
                                  birth_date = pers.birth_date.Value,
                                  email = pers.email,
                                  phone_number = pers.phone_number
                              });

                return result;
            }
            catch (Exception)
            {

                return null;
            }

        }


        public IEnumerable<CardDataModel> GetCardData(int card_ID)
        {
            try
            {
                var result = (from c in db.Bank_Card
                              where c.card_ID == card_ID
                              select new CardDataModel
                              {
                                  card_ID = c.card_ID,
                                  card_number = c.card_number,
                                  expiring_date = c.expiring_date.Value,
                                  cvv = c.cvv.Value,
                                  bank_name = c.bank_name
                              });

                return result;
            }
            catch (Exception)
            {

                return null;
            }

        }
    
        public string UpdateMyProfile(PersonalDataModel pd)
        {
            var prof = (from p in db.Personal_Data where p.data_ID == pd.data_ID select p).First();

            try
            {
                prof.p_name = pd.p_name;
                prof.p_surname = pd.p_surname;
                prof.p_secondname = pd.p_secondname;
                prof.birth_date = pd.birth_date;
                prof.email = pd.email;
                prof.phone_number = pd.phone_number;
                db.SaveChanges();
                return "Success";
            }
            catch (Exception)
            {
                return "Error";
                throw;
            }

        }

        public string UpdateBankCard(CardDataModel pd)
        {
            var prof = (from p in db.Bank_Card where p.card_ID == pd.card_ID select p).First();

            try
            {
                prof.card_number = pd.card_number;
                prof.expiring_date = pd.expiring_date;
                prof.cvv = pd.cvv;
                prof.bank_name = pd.bank_name;            
                db.SaveChanges();
                return "Success";
            }
            catch (Exception)
            {
                return "Error";
                throw;
            }

        }
    }
}