using SmartDeliveryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDeliveryAPI.Interfaces
{
    internal interface IAuthService
    {
        ICollection<AuthModel> GetClientToken(string login, string password);
    }
}
