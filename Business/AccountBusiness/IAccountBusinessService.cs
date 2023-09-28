using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Business.AccountBusiness
{
    public interface IAccountBusinessService
    {
        void AddAccount(AccountVM model);
        bool Login(string email, string password);
       
    }
}
