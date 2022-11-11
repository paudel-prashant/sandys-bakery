using SandysBakery.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandysBakery.DataAccess.Services
{
    public interface IUsers
    {
        MessageReturnType UserRegistration(UsersRegistration usersRegistration);
        DataTable ValidateExistingUser(string username);
        UsersLogin UserLogin(UsersLogin usersLogin);
        List<Roles> GetRole();
        MessageReturnType EditUsers(UsersRegistration usersRegistration);
        UsersRegistration GetUserDetailsById(int registrationId);
        DataTable UsersList(int userId);
    }
}
