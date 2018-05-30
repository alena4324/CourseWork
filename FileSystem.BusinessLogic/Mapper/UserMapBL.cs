using FileSystem.BusinessLogic.Interface.Models;
using FileSystem.DataAccess.Interface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.BusinessLogic.Mapper
{
    public static class UserMapBL
    {
        public static UserModelBL UserModelDAToUserModelBL(UserModelDA user)
        {
            var newUser = new UserModelBL()
            {
                Login = user.Login,
                Password = user.Password,
                IsActive = user.IsActive
                //Roles = new List<RoleModelBL>()
            };
            if (user.Roles == null)
                return newUser;
            newUser.Roles = new List<RoleModelBL>();

            user.Roles.ToList().ForEach(s => newUser.Roles.Add(new RoleModelBL { Name = s.Name, Id = s.Id }));

            return newUser;
        }

        public static UserModelDA UserModelBLToUserModelDA(UserModelBL user)
        {
            var newUser = new UserModelDA()
            {
                Login = user.Login,
                Password = user.Password,
                IsActive = user.IsActive
                // Roles = new List<RoleModelDA>()
            };
            if (user.Roles == null)
                return newUser;
            newUser.Roles = new List<RoleModelDA>();

            user.Roles.ToList().ForEach(s => newUser.Roles.Add(new RoleModelDA { Name = s.Name, Id = s.Id }));

            return newUser;
        }
    }
}
