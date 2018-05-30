using FileSystem.DataAccess.Interface.Models;
using FileSystem.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.DataAccess.Mapper
{
    public static class RoleMapDA
    {
        public static Role RoleModelDAToRole(RoleModelDA role)
        {
            var newRole = new Role()
            {
                Id = role.Id,
                Name = role.Name,               
            };

            if (role.Users == null)
                return newRole;

            newRole.Users = new List<User>();

            role.Users.ToList().ForEach(s => newRole.Users.Add(new User {
                Login = s.Login,
                Password = s.Password,
                IsActive = s.IsActive
            }));

            return newRole;
        }

        public static RoleModelDA RoleToRoleModelDA(Role role)
        {
            var newRole = new RoleModelDA()
            {
                Id=role.Id,
                Name = role.Name,                
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
