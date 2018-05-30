using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using FileSystem.BusinessLogic.Interface.Interfaces;
using Moq;
using FileSystem.BusinessLogic.Interface.Models;
using System.Web.Mvc;

namespace FileSystem.Controllers.Tests
{
    [TestClass]
    public class AdminControllerTests
    {
        Mock<IUserService> mockUserService;

        AdminController controller;

        [TestInitialize]
        public void Initialize()
        {
            mockUserService = new Mock<IUserService>();

            controller = new AdminController(mockUserService.Object);
        }

        [TestMethod]
        public void AdminController_GetAllUsersTest_ReturnCorrectView()
        {
            mockUserService.Setup(u => u.GetAllUsers()).Returns(new List<UserModelBL>());
            var result = controller.GetAllUsers() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("GetAllUsers", result.ViewName);
        }

        [TestMethod]
        public void AdminController_ChangeRoleTest_AddRoleAdminToUser_ReturnCorrectView()
        {
            var gettingUser = new UserModelBL() { Login = "admin", Password = "12345", IsActive = true,
                Roles = new List<RoleModelBL>() { new RoleModelBL() { Name = "user", Id = 1 } } };

            mockUserService.Setup(u => u.AddRoleToUser(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            mockUserService.Setup(u => u.GetUserByLogin(It.IsAny<string>())).Returns(gettingUser);
            mockUserService.Setup(u => u.GetAllUsers()).Returns(new List<UserModelBL>());

            var result = controller.ChangeRole("user", "user") as ViewResult;

            Assert.IsNotNull(result);
            mockUserService.Verify(a => a.AddRoleToUser("user", "user"));
        }

        [TestMethod]
        public void AdminController_ChangeRoleTest_RemoveRoleAdminFromUser_ReturnCorrectView()
        {
            var gettingUser = new UserModelBL()
            {
                Login = "admin",
                Password = "12345",
                IsActive = true,
                Roles = new List<RoleModelBL>() { new RoleModelBL() { Name = "user", Id = 1 }, new RoleModelBL() { Name = "admin", Id = 2 } }
            };

            mockUserService.Setup(u => u.RemoveRoleFromUser(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            mockUserService.Setup(u => u.GetUserByLogin(It.IsAny<string>())).Returns(gettingUser);
            mockUserService.Setup(u => u.GetAllUsers()).Returns(new List<UserModelBL>());

            var result = controller.ChangeRole("user", "admin") as ViewResult;

            Assert.IsNotNull(result);
            mockUserService.Verify(a => a.RemoveRoleFromUser("admin", "user"));
        }

        [TestMethod]
        public void AdminController_ChangeRoleTest_EmptyLogin_ReturnErrorView()
        {
            var result = controller.ChangeRole("", "user") as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void AdminController_DeleteUserTest_CorrectData_ReturnCorrectView()
        {
            var gettingUser = new UserModelBL()
            {
                Login = "login",
                Password = "12345",
                IsActive = true,
                Roles = new List<RoleModelBL>() { new RoleModelBL() { Name = "user", Id = 1 } }
            };

            mockUserService.Setup(u => u.DeleteUser(It.IsAny<string>())).Returns(true);
            mockUserService.Setup(u => u.GetUserByLogin(It.IsAny<string>())).Returns(gettingUser);
            mockUserService.Setup(u => u.GetAllUsers()).Returns(new List<UserModelBL>());

            var result = controller.DeleteUser("login") as ViewResult;

            Assert.IsNotNull(result);
            mockUserService.Verify(a => a.DeleteUser("login"));
            Assert.AreEqual("GetAllUsers", result.ViewName);
        }

        [TestMethod]
        public void AdminController_DeleteUserTest_EmptyLogin_ReturnErrorView()
        {

            var result = controller.DeleteUser("") as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void AdminController_RenewUserTest_CorrectData_ReturnCorrectView()
        {
            var gettingUser = new UserModelBL()
            {
                Login = "login",
                Password = "12345",
                IsActive = true,
                Roles = new List<RoleModelBL>() { new RoleModelBL() { Name = "user", Id = 1 } }
            };

            mockUserService.Setup(u => u.RenewUser(It.IsAny<string>())).Returns(true);
            mockUserService.Setup(u => u.GetUserByLogin(It.IsAny<string>())).Returns(gettingUser);
            mockUserService.Setup(u => u.GetAllUsers()).Returns(new List<UserModelBL>());

            var result = controller.RenewUser("login") as ViewResult;

            Assert.IsNotNull(result);
            mockUserService.Verify(a => a.RenewUser("login"));
            Assert.AreEqual("GetAllUsers", result.ViewName);
        }

        [TestMethod]
        public void AdminController_RenewUserTest_EmptyLogin_ReturnErrorView()
        {

            var result = controller.RenewUser("") as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Error", result.ViewName);
        }
    }
}