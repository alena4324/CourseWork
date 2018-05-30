using FileSystem.BusinessLogic.Interface.Interfaces;
using FileSystem.BusinessLogic.Interface.Models;
using FileSystem.BusinessLogic.Mapper;
using FileSystem.Models;
using System;
using System.Collections.Generic;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace FileSystem.Providers
{
    public class CustomMembershipProvider : MembershipProvider
    {
        public IUserService UserService { get; private set;  } 

        public CustomMembershipProvider(IUserService userService)
        {
            UserService = userService; 
        }
        public CustomMembershipProvider()
        {
        }

        //public MembershipUser CreateUser(string login, string password)
        //{
        //    MembershipUser membershipUser = GetUser(login, false);

            //    if (membershipUser != null)
            //    {
            //        return null;
            //        //throw new Exception("The user with such a login is exist");
            //    }


            //    UserModelBL user = new UserModelBL()
            //    {
            //        Login = login,
            //        Password = Crypto.HashPassword(password),
            //        Roles = new List<RoleModelBL>()
            //    };

            //    //user.Roles.Add(RoleService.GetRoleByName("user") );

            //    UserService.CreateUser(user);

            //    return GetUser(login, true);
            //}

        public override MembershipUser GetUser(string login, bool userIsOnline)
        {
            var user = UserService.GetUserByLogin(login);

            if (user == null)
                return null;

            var memberUser = new MembershipUser("CustomMembershipProvider",
                user.Login, null, null, null, null,
                false, false, DateTime.MinValue,
                DateTime.MinValue, DateTime.MinValue,
                DateTime.MinValue, DateTime.MinValue);

            return memberUser;
        }

        public override bool ValidateUser(string login, string password)
        {
            var user = UserService.GetUserByLogin(login);

            return user != null && Crypto.VerifyHashedPassword(user.Password, password) && user.IsActive;
        }

        //public List<UserModelMVC> GetAllUsers()
        //{
        //    var users = new List<UserModelMVC>();

        //    UserService.GetAllUsers().ForEach(u=>users.Add(UserMapMVC.UserModelBLToUserModeMVC(u)));
        //    return users;
        //}

        //public bool ChangePassword(string login, string newPassword)
        //{
        //    if (login == null || newPassword == null)
        //        return false;

        //    var user = UserService.GetUserByLogin(login);

        //    if (user == null)
        //        return false;

        //    var result = UserService.ChangePassword(login, Crypto.HashPassword(newPassword));
        //    if(result==true)
        //        return true;

        //    return false;
        //}

        //public bool RenewUser(string login)
        //{
        //    if (login == null)
        //        return false;

        //    var user = UserService.GetUserByLogin(login);

        //    if (user == null)
        //        return false;

        //    var result = UserService.RenewUser(login);
        //    if (result == true)
        //        return true;

        //    return false;
        //}


        public override bool EnablePasswordRetrieval => throw new NotImplementedException();

        public override bool EnablePasswordReset => throw new NotImplementedException();

        public override bool RequiresQuestionAndAnswer => throw new NotImplementedException();

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override int MaxInvalidPasswordAttempts => throw new NotImplementedException();

        public override int PasswordAttemptWindow => throw new NotImplementedException();

        public override bool RequiresUniqueEmail => throw new NotImplementedException();

        public override MembershipPasswordFormat PasswordFormat => throw new NotImplementedException();

        public override int MinRequiredPasswordLength => throw new NotImplementedException();

        public override int MinRequiredNonAlphanumericCharacters => throw new NotImplementedException();

        public override string PasswordStrengthRegularExpression => throw new NotImplementedException();

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }        

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }
    }
}
