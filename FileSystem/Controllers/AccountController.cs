using FileSystem.BusinessLogic.Interface.Interfaces;
using FileSystem.Models;
using FileSystem.Providers;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FileSystem.Controllers
{
    public class AccountController : Controller
    {
        IUserService _userService;

        MembershipProvider _membershipProvider;


        public AccountController(IUserService userService) { 

            _userService = userService;
            _membershipProvider = new CustomMembershipProvider(userService);
        }

        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("AllDrives", "Directory");
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LogOnViewModel model, string returnUrl)
        {            
            if (ModelState.IsValid)
            {
                if (_membershipProvider.ValidateUser(model.Login, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Login, false);

                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("AllDrives", "Directory");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Login or password is wrong");
                }
            }
            return View(model);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _userService.CreateUser(model.Login, model.Password);

                    if (user)
                    {
                        FormsAuthentication.SetAuthCookie(model.Login, false);
                        return RedirectToAction("AllDrives", "Directory");
                    }
                    else
                        throw new Exception("The user with such a login is exist. Choose another login");

                }
                else
                    throw new Exception("Registration error");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }           
        }

        public ActionResult ChangePassword()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult ChangePassword(string login, string password)
        {
            var result = _userService.ChangePassword(login, password);

            if (result)
                return PartialView("ChangePassword");
            else
                return View("Error");
        }           
    }
}