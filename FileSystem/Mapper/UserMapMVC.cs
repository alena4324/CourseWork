using FileSystem.BusinessLogic.Interface.Models;
using FileSystem.Models;
using System.Linq;
using System.Collections.Generic;

namespace FileSystem.BusinessLogic.Mapper
{
    public static class UserMapMVC
    {
        public static UserModelBL UserModelMVCToUserModelBL(UserModelMVC user)
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

        public static UserModelMVC UserModelBLToUserModeMVC(UserModelBL user)
        {
            var newUser = new UserModelMVC()
            {
                Login = user.Login,
                Password = user.Password,
                IsActive = user.IsActive
                //Roles = new List<RoleModelMVC>()
            };

            if (user.Roles == null)
                return newUser;

            newUser.Roles = new List<RoleModelMVC>();

            user.Roles.ToList().ForEach(s => newUser.Roles.Add(new RoleModelMVC { Name = s.Name, Id = s.Id }));

            return newUser;
        }
    }
}
