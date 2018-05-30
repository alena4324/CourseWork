using FileSystem.DataAccess.Interface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.DataAccess.Interface.Interfaces
{
    public interface IUserRepository
    {
        bool Create(UserModelDA user);

        bool Delete(string login);

        UserModelDA GetUserById(int id);

        UserModelDA GetUserByLogin(string login);

        List<UserModelDA> GetAllUsers();

        bool UpdateUser(UserModelDA user);
    }
}
