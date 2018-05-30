using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileSystem.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSystem.Models;
using FileSystem.BusinessLogic.Interface.Interfaces;
using Moq;
using FileSystem.BusinessLogic.Interface.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace FileSystem.Controllers.Tests
{
    [TestClass]
    public class AccountControllerTests
    {
        Mock<IUserService> mockUserService;
        Mock<IRoleService> mockRoleService;

        AccountController controller;


        [TestInitialize]
        public void Initialize()
        {
 
            mockUserService = new Mock<IUserService>();
            mockRoleService = new Mock<IRoleService>();

            controller = new AccountController(mockUserService.Object);

        }     

        [TestMethod]
        public void AccountController_ChangePasswordTest_CorrectData_ReturnedCorrectView()
        {
            mockUserService.Setup(u => u.ChangePassword(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            var result = controller.ChangePassword("user", "1234") as PartialViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("ChangePassword", result.ViewName);
        }

        [TestMethod]
        public void AccountController_ChangePasswordTest_EmptyLogin_ReturnedErrorView()
        {
            mockUserService.Setup(u => u.ChangePassword(It.IsAny<string>(), It.IsAny<string>())).Returns(false);

            var result = controller.ChangePassword("", "1234") as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Error", result.ViewName);
        }
    }
}