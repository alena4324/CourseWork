using FileSystem.BusinessLogic.Interface.Models;
using FileSystem.DataAccess.Interface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.BusinessLogic.Mapper
{
    public static class RoleMapBL
    {
        public static RoleModelBL RoleModelDAToRoleModelBL(RoleModelDA role)
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
                Login = s.Login,
                Password = s.Password,
                IsActive = s.IsActive
            }));

            return newRole;
        }

        public static RoleModelDA RoleModelBLToRoleModelDA(RoleModelBL role)
        {
            var newRole = new RoleModelDA()
            {
                Id=role.Id,
                Name = role.Name,
                //Users = new List<UserModelDA>()
            };

            if (role.Users == null)
                return newRole;

            newRole.Users = new List<UserModelDA>();

            role.Users.ToList().ForEach(s => newRole.Users.Add(new UserModelDA
            {
                Login = s.Login,
                Password = s.Password,
                IsActive = s.IsActive
            }));

            return newRole;
        }
    }
}
