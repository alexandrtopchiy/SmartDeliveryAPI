using SmartDeliveryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDeliveryAPI.Interfaces
{
    internal interface IProfileService
    {

        IEnumerable<ProfileInfo> GetClientProfile(int token);

        IEnumerable<PersonalDataModel> GetPersonalData(int token);
        IEnumerable<CardDataModel> GetCardData(int card_ID);
        string UpdateMyProfile(PersonalDataModel pd);
        string UpdateBankCard(CardDataModel pd);

    }
}
