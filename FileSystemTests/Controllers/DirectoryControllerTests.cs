using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileSystem.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using FileSystem.BusinessLogic.Interface.Interfaces;
using System.Web.Mvc;
using System.IO;

namespace FileSystem.Controllers.Tests
{
    [TestClass]
    public class DirectoryControllerTests
    {
        Mock<IFileService> mockFileService;

        DirectoryController controller;
        

        [TestInitialize]
        public void Initialize()
        {
            mockFileService = new Mock<IFileService>();        

            controller = new DirectoryController(mockFileService.Object);
        }

        [TestMethod]
        public void DirectoryController_CreateNewItemTest_CreateFolder_ReturnedCorrectView()
        {
            //controller = new DirectoryController(mockFileService.Object);
            //controller.ControllerContext = new ControllerContext(HttpContextBaseMock.Object, new RouteData(), controller);
            mockFileService.Setup(a => a.CreateFolder(It.IsAny<string>(), It.IsAny<string>())).Returns(true);


            var result = (RedirectToRouteResult)controller.CreateNewItem("D\\", "yui", null);

            Assert.IsNotNull(result);
            Assert.AreEqual("Table", result.RouteValues["action"]);
        }

        [TestMethod]
        public void DirectoryController_CreateNewItemTest_EmptyPathAndName_ReturnedStatus400()
        {
            //controller = new DirectoryController(mockFileService.Object);
            //controller.ControllerContext = new ControllerContext(HttpContextBaseMock.Object, new RouteData(), controller);
            mockFileService.Setup(a => a.CreateFolder(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            var result = controller.CreateNewItem("", "", null) as HttpStatusCodeResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }

        [TestMethod]
        public void DirectoryController_CreateNewItemTest_CreateFile_ReturnedCorrectView()
        {
            mockFileService.Setup(a => a.CreateFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            //controller = new DirectoryController(mockFileService.Object);
            //controller.ControllerContext = new ControllerContext(HttpContextBaseMock.Object, new RouteData(), controller);

            var result = (RedirectToRouteResult)controller.CreateNewItem("D\\", "yui", "txt");

            Assert.IsNotNull(result);
            Assert.AreEqual("Table", result.RouteValues["action"]);
        }

        [TestMethod]
        public void DirectoryController_CreateNewItemTest_EmptyPath_ReturnedStatus400()
        {
            //controller = new DirectoryController(mockFileService.Object);
            //controller.ControllerContext = new ControllerContext(HttpContextBaseMock.Object, new RouteData(), controller);

            var result = controller.CreateNewItem("", "yui", "txt") as HttpStatusCodeResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }

        [TestMethod()]
        public void DirectoryController_DeleteFolderTest_DeleteFolder_ReturnedCorrectView()
        {
            mockFileService.Setup(a => a.DeleteFolder(It.IsAny<string>())).Returns(true);

            var result = controller.DeleteFolder("D\\hhhhh") as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Table", result.RouteValues["action"]);
        }

        [TestMethod()]
        public void DirectoryController_DeleteFileTest_DeleteFile_ReturnedCorrectView()
        {
            //controller = new DirectoryController(mockFileService.Object);
            //controller.ControllerContext = new ControllerContext(HttpContextBaseMock.Object, new RouteData(), controller);
            mockFileService.Setup(a => a.DeleteFile(It.IsAny<string>())).Returns(true);


            var result = controller.DeleteFile("D\\hhhhh\\New Text Document.txt") as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Table", result.RouteValues["action"]);
        }

        [TestMethod]
        public void DirectoryController_DeleteFolderTest_EmptyPath_ReturnedStatus400()
        {
            mockFileService.Setup(a => a.DeleteFolder(It.IsAny<string>())).Returns(false);

            //controller = new DirectoryController(mockFileService.Object);
            //controller.ControllerContext = new ControllerContext(HttpContextBaseMock.Object, new RouteData(), controller);

            var result = controller.DeleteFolder("") as HttpStatusCodeResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }

        [TestMethod]
        public void DirectoryController_DeleteFileTest_EmptyPath_ReturnedStatus400()
        {

            var result = controller.DeleteFile("") as HttpStatusCodeResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }

        [TestMethod()]
        public void DirectoryController_TableTest_ExistPath_ReturnedCorrectView()
        {
            mockFileService.Setup(a => a.IsExistPath(It.IsAny<string>())).Returns(true);

            var result = controller.Table("D\\New") as PartialViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Table", result.ViewName);

        }

        [TestMethod()]
        public void DirectoryController_TableTest_NotExistPath_ReturnedStatus400()
        {
            mockFileService.Setup(a => a.IsExistPath(It.IsAny<string>())).Returns(false);

            var result = controller.Table("D\\Nerereweee") as HttpStatusCodeResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);

        }

        [TestMethod()]
        public void DirectoryController_TableTest_EmptyPath_ReturnedStatus400()
        {
            mockFileService.Setup(a => a.IsExistPath(It.IsAny<string>())).Returns(false);

            var result = controller.Table("") as HttpStatusCodeResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);

        }

        [TestMethod()]
        public void DirectoryController_GetAllFilesTest_ExistPath_ReturnedCorrectView()
        {
            mockFileService.Setup(a => a.GetAllFiles(It.IsAny<string>())).Returns(new List<FileSystemInfo>());
            mockFileService.Setup(a => a.IsExistPath(It.IsAny<string>())).Returns(true);

            var result = controller.GetAllFiles("D\\New") as PartialViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("GetAllFiles", result.ViewName);
        }

        [TestMethod()]
        public void DirectoryController_GetAllFilesTest_NotExistPath_ReturnedStatus400()
        {
            mockFileService.Setup(a => a.GetAllFiles(It.IsAny<string>())).Returns(new List<FileSystemInfo>());
            mockFileService.Setup(a => a.IsExistPath(It.IsAny<string>())).Returns(false);

            var result = controller.GetAllFiles("D\\Nty7uewww") as HttpStatusCodeResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }

        [TestMethod()]
        public void DirectoryController_SearchFilesTest_RightPath_ReturnCorrectModel()
        {
            mockFileService.Setup(a => a.SearchFiles(It.IsAny<string>(), It.IsAny<string>())).Returns(new Dictionary<string, string>() { { "D:\\Hello\\New", "folder" }, { "D:\\Hello\\New\\New11.txt", "file" } });

            var result = controller.SearchFiles("D\\Hello", "New") as PartialViewResult;

            Assert.IsNotNull(result);
            // mockFileService.Verify(a => a.SearchFiles("D:\\Hello", "New"));
            Assert.AreEqual("SearchFiles", result.ViewName);

        }
    }
}