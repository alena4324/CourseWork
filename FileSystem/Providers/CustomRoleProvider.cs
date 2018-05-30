using FileSystem.BusinessLogic.Interface.Interfaces;
using FileSystem.BusinessLogic.Interface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;

namespace FileSystem.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        public IRoleService RoleService { get; private set; }

        public IUserService UserService { get; private set; }

        public CustomRoleProvider()
        {
            UserService = (IUserService)DependencyResolver.Current.GetService(typeof(IUserService)); ;
            RoleService = (IRoleService)DependencyResolver.Current.GetService(typeof(IRoleService)); ;
        }

        public override bool IsUserInRole(string login, string roleName)
        {
            var user = UserService.GetUserByLogin(login);

            if (user == null)
                return false;

            var role = RoleService.GetRoleByName(roleName);

            return user.Id == role?.Id;
        }

        public override string[] GetRolesForUser(string login)
        {
            var user = UserService.GetUserByLogin(login);

            if (user == null)
                return null;

            int count = 0;

            var userRoles = new string[user.Roles.Count];

            user.Roles.ToList().ForEach(r=>userRoles[count++]=r.Name);

            return userRoles;
        }

        public override void CreateRole(string roleName)
        {
            RoleService.CreateRole(new RoleModelBL() { Name = roleName });
        }     

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
