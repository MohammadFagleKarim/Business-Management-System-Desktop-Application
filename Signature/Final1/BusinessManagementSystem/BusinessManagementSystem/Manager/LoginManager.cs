using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessManagementSystem.Repository;
using BusinessManagementSystem.Model;

namespace BusinessManagementSystem.Manager
{
    class LoginManager
    {
        LoginRepo _loginRepo = new LoginRepo();

        public bool Login(Login login)
        {
            return _loginRepo.Login(login);
        }
    }
}
