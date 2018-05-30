using FileSystem.BusinessLogic.Interface.Models;
using FileSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.BusinessLogic.Mapper
{
    public static class RoleMapMVC
    {
        public static RoleModelBL RoleModelMVCToRoleModelBL(RoleModelMVC role)
        {
            var newRole = new RoleModelBL()
            {
                Id=role.Id,
                Name = role.Name,
                //Users = new List<UserModelBL>()
            };

            if (role.Users == null)
                return newRole;

            newRole.Users = new List<UserModelBL>();

            role.Users.ToList().ForEach(s => newRole.Users.Add(new UserModelBL {
                Id=s.Id,
                Login = s.Login,
                Password = s.Password,
                IsActive = s.IsActive
            }));

            return newRole;
        }

        public static RoleModelMVC RoleModelBLToRoleModelDA(RoleModelBL role)
        {
            var newRole = new RoleModelMVC()
            {
                Id=role.Id,
                Name = role.Name,
                //Users = new List<UserModelMVC>()
            };

            if (role.Users == null)
                return newRole;

            newRole.Users = new List<UserModelMVC>();

            role.Users.ToList().ForEach(s => newRole.Users.Add(new UserModelMVC
            {
                Id=s.Id,
                Login = s.Login,
                Password = s.Password,
                IsActive = s.IsActive
            }));

            return newRole;
        }
    }
}
