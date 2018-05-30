using FileSystem.DataAccess.Interface.Models;
using FileSystem.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.DataAccess.Mapper
{
    public static class UserMapDA
    {
        public static User UserModelDAToUser(UserModelDA user)
        {
            var newUser = new User()
            {
                Login = user.Login,
                Password = user.Password, 
                IsActive = user.IsActive
                //Roles = new List<Role>()
            };
            if (user.Roles == null)
                return newUser;
            newUser.Roles = new List<Role>();

            user.Roles.ToList().ForEach(s => newUser.Roles.Add(new Role { Name = s.Name, Id = s.Id }));

            return newUser;
        }

        public static UserModelDA UserToUserModelDA(User user)
        {
            var newUser = new UserModelDA()
            {
                Login = user.Login,
                Password = user.Password,
                IsActive = user.IsActive
                //Roles = new List<RoleModelDA>()
            };
            if (user.Roles == null)
                return newUser;
            newUser.Roles = new List<RoleModelDA>();

            user.Roles.ToList().ForEach(s => newUser.Roles.Add(new RoleModelDA { Name = s.Name, Id = s.Id }));

            return newUser;
        }
    }
}
