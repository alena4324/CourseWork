using FileSystem.BusinessLogic.Interface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.BusinessLogic.Interface.Interfaces
{
    public interface IUserService
    {
        bool CreateUser(/*UserModelBL user*/string login, string password);

        bool DeleteUser(string login);

        UserModelBL GetUserByLogin(string login);

        List<UserModelBL> GetAllUsers();

        bool RemoveRoleFromUser(string roleName, string userLogin);

        bool AddRoleToUser(string roleName, string userLogin);

        bool ChangePassword(string login, string password);

        bool RenewUser(string login);
    }
}
