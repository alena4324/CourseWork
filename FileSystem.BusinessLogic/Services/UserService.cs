using FileSystem.BusinessLogic.Interface.Interfaces;
using FileSystem.BusinessLogic.Interface.Models;
using FileSystem.BusinessLogic.Models;
using FileSystem.DataAccess.Interface.Interfaces;
using FileSystem.DataAccess.Repositories;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using FileSystem.BusinessLogic.Mapper;
using System.Web.Helpers;

namespace FileSystem.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        IRoleService _roleService;

        public UserService(IUserRepository userRepository, IRoleService roleService)
        {
            _userRepository = userRepository;
            _roleService = roleService;
        }

        public bool CreateUser(/*UserModelBL user*/ string login, string password)
        {
            if (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(password))
                return false;

            var newUser = _userRepository.GetUserByLogin(login);

            if(newUser!=null)
                return false;

            UserModelBL user = new UserModelBL()
            {
                Login = login,
                Password = Crypto.HashPassword(password),
                Roles = new List<RoleModelBL>()
            };

            _userRepository.Create(UserMapBL.UserModelBLToUserModelDA(user));

            return true;
        }

        public bool DeleteUser(string login)
        {
            var user = _userRepository.GetUserByLogin(login);

            if (user == null)
                return false;

            _userRepository.Delete(user.Login);

            return true;
        }

        public List<UserModelBL> GetAllUsers()
        {
            var users = new List<UserModelBL>();

            _userRepository.GetAllUsers().ForEach(u=>users.Add(UserMapBL.UserModelDAToUserModelBL(u)));

            return users;
        }

        public UserModelBL GetUserByLogin(string login)
        {
            var user = _userRepository.GetUserByLogin(login);

            if (user != null)
                return UserMapBL.UserModelDAToUserModelBL(user);

            return null;
        }

        public bool AddRoleToUser(string roleName, string userLogin)
        {
            var user = GetUserByLogin(userLogin);
            if (user == null)
                return false;

            var role = _roleService.GetRoleByName(roleName);

            user.Roles.Add(role);

            _userRepository.UpdateUser(UserMapBL.UserModelBLToUserModelDA(user));

            return true;
        }

        public bool RemoveRoleFromUser(string roleName, string userLogin)
        {
            var user = GetUserByLogin(userLogin);
            if (user == null)
                return false;

            var role = user.Roles.Where(r => r.Name == roleName).FirstOrDefault();

            if (role != null)
                user.Roles.Remove(role);

            _userRepository.UpdateUser(UserMapBL.UserModelBLToUserModelDA(user));

            return true;
        }

        public bool ChangePassword(string userLogin, string password)
        {
            if (userLogin == null || password == null)
                return false;

            var user = GetUserByLogin(userLogin);
            if (user == null)
                return false;

            user.Password = Crypto.HashPassword(password);

            _userRepository.UpdateUser(UserMapBL.UserModelBLToUserModelDA(user));

            return true;
        }

        public bool RenewUser(string userLogin)
        {
            if (userLogin == null)
                return false;

            var user = GetUserByLogin(userLogin);
            if (user == null)
                return false;

            user.IsActive = true;

            var result = _userRepository.UpdateUser(UserMapBL.UserModelBLToUserModelDA(user));
            if(result)
                return true;

            return false;
        }
    }
}
