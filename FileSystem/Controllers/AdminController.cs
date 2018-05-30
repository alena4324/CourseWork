using FileSystem.BusinessLogic.Interface.Interfaces;
using FileSystem.BusinessLogic.Mapper;
using FileSystem.Models;
using FileSystem.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileSystem.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Admin        
        public ActionResult GetAllUsers()
        {
            var users = new List<UserModelMVC>();

            _userService.GetAllUsers().ForEach(u => users.Add(UserMapMVC.UserModelBLToUserModeMVC(u)));


            return View("GetAllUsers",users);
        }

        public ActionResult ChangeRole(string login, string roleName="admin")
        {
            if (String.IsNullOrEmpty(login))
                return View("Error", "The login is empty");

            var user = UserMapMVC.UserModelBLToUserModeMVC(_userService.GetUserByLogin(login));

            //if (user == null)
            //    return View("Error");

            var roleAdmin = user.Roles.Where(r => r.Name == "admin").SingleOrDefault();

            bool result;

            if (roleAdmin == null)
                result = _userService.AddRoleToUser(roleName, login);
            else
                result = _userService.RemoveRoleFromUser(roleName, login);

            var users = new List<UserModelMVC>();
            _userService.GetAllUsers().ForEach(u => users.Add(UserMapMVC.UserModelBLToUserModeMVC(u)));

            //if (!result)
            //    return View("GetAllUsers", new CustomMembershipProvider().GetAllUsers());

            //return View("Error");
            return View("GetAllUsers", users);
        }

        [HttpPost]
        public ActionResult DeleteUser(string login)
        {
            if (String.IsNullOrEmpty(login))
                return View("Error", "The login is empty");

            var user = _userService.GetUserByLogin(login);

            //if (user == null)
            //    return View("Error");

            bool result;

            result = _userService.DeleteUser(login);

            var users = new List<UserModelMVC>();
            _userService.GetAllUsers().ForEach(u => users.Add(UserMapMVC.UserModelBLToUserModeMVC(u)));

            //if (result)
            //    return View("GetAllUsers", new CustomMembershipProvider().GetAllUsers());

            //return View("Error");
            return View("GetAllUsers", users);
        }
        public ActionResult ConfirmDeletingUser(string login)
        {
             if (login == null)
                return HttpNotFound();

            var user = _userService.GetUserByLogin(login);

            if(user==null)
                return HttpNotFound();

            return PartialView("ConfirmDeletingUser", login);          
        }

        public ActionResult RenewUser(string login)
        {
            if (String.IsNullOrEmpty(login))
                return View("Error", "The login is empty");

            var user = _userService.GetUserByLogin(login);

            //if (user == null)
            //    return View("Error");

            bool result;

            result = _userService.RenewUser(login);

            var users = new List<UserModelMVC>();
            _userService.GetAllUsers().ForEach(u => users.Add(UserMapMVC.UserModelBLToUserModeMVC(u)));


            //if (result)
            //    return View("GetAllUsers", new CustomMembershipProvider().GetAllUsers());

            //return View("Error");
            return View("GetAllUsers", users);
        }
    }
}