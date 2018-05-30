using FileSystem.BusinessLogic.Interface.Interfaces;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace FileSystem.Controllers
{
    [Authorize]
    public class DirectoryController : Controller
    {
        private IFileService _fileService;

        public DirectoryController(IFileService fileService)
        {
            _fileService = fileService;
        }
        
        public ActionResult AllDrives()
        {
            var paths = _fileService.GetAllDrives();

            return View(paths);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult CreateNewItem(string pathA, string name, string type)
        {
            if (String.IsNullOrEmpty(pathA) || String.IsNullOrEmpty(name))
                return new HttpStatusCodeResult(400); //View("Error", "The path or name is empty");

            if (string.IsNullOrEmpty(type))
                type = "folder";

            string root;

            if (!pathA.Contains(":"))
                root = pathA.Insert(1, @":/");
            else
                root = pathA;

            if (type == "folder")
            {
                _fileService.CreateFolder(root, name);
            }
            else
            {
                _fileService.CreateFile(root, name, type);
            }

            return RedirectToAction("Table", "Directory", new { path = pathA });
        }

        [HttpPost]
        public ActionResult DeleteFolder(string path)
        {
            if (String.IsNullOrEmpty(path))
                return new HttpStatusCodeResult(400); //return View("Error", "The path is empty");

            string root;

            if (!path.Contains(":"))
                root = path.Insert(1, @":/");
            else
                root = path;

            var parentPath = Directory.GetParent(root).FullName;

            _fileService.DeleteFolder(root);

            return RedirectToAction("Table", "Directory", new { path = parentPath.Replace(":", "") });
        }

        [HttpPost]
        public ActionResult DeleteFile(string path)
        {
            if (String.IsNullOrEmpty(path))
                return new HttpStatusCodeResult(400); //return View("Error", "The path is empty");

            //string root;

            //if (!path.Contains(":"))
            //    root = new Regex(@"^(.+(?=\/)|.+$)").Match(path.Insert(1, @":/")).Value;
            //else
            //    root = new Regex(@"^(.+(?=\/)|.+$)").Match(path).Value;

            string root;

            if (!path.Contains(":"))
                root = path.Insert(1, @":/");
            else
                root = path;

            var parentPath = Directory.GetParent(root).FullName;

            _fileService.DeleteFile(root);

            return RedirectToAction("Table", "Directory", new { path = parentPath.Replace(":", "") });
        }

        [HttpPost]
        public ActionResult ConfirmDeletingFile(string path, string type)
        {
            if (String.IsNullOrEmpty(path) || String.IsNullOrEmpty(type))
                return new HttpStatusCodeResult(400); //return View("Error", "The path is empty");

            string root;

            if (!path.Contains(":"))
                root = new Regex(@"^(.+(?=\/)|.+$)").Match(path.Insert(1, @":/")).Value;
            else
                root = new Regex(@"^(.+(?=\/)|.+$)").Match(path).Value;

            var file = new FileInfo(root+"."+type);

            return PartialView("ConfirmDeletingFile", file);
        }

        public ActionResult ConfirmDeletingDirectory(string path)
        {
            if (String.IsNullOrEmpty(path))
                return new HttpStatusCodeResult(400); //return View("Error", "The path is empty");

            string root;

            if (!path.Contains(":"))
                root = path.Insert(1, @":/");
            else
                root = path;

            var directory= new DirectoryInfo(root);

            return PartialView("ConfirmDeletingDirectory", directory);
        }

        public ActionResult Table(string path)
        {
            if (String.IsNullOrEmpty(path))
                return new HttpStatusCodeResult(400);//return View("Error", "The path is empty");

            string root;

            if (!path.Contains(":"))
                root = path.Insert(1, @":/");
            else
                root = path;

            bool result = _fileService.IsExistPath(root);

            if (result)
                return PartialView("Table", path);

            return new HttpStatusCodeResult(400);
        }

        public ActionResult GetAllFiles(string path)
        {
            if (String.IsNullOrEmpty(path))
                return new HttpStatusCodeResult(400);//View("Error", "The path is empty");

            string root;

            if (!path.Contains(":"))
                root = path.Insert(1, @":/");
            else
                root = path;

            var result = _fileService.IsExistPath(root);

            if(result==false)
                return new HttpStatusCodeResult(400);
            //return View("Error");

            var directories = _fileService.GetAllFiles(root); //new DirectoryInfo(root).EnumerateFileSystemInfos();

            //if (directories == null)
            //{
            //    //return View("Error");
            //}

            return PartialView("GetAllFiles",directories);
        }

        public ActionResult SearchFiles(string path, string name)
        {
            if (String.IsNullOrEmpty(path) || String.IsNullOrEmpty(name))
                return new HttpStatusCodeResult(400); //return View("Error", "The path or name is empty");

            string root;

            if (!path.Contains(":"))
                root = path.Insert(1, @":/");
            else
                root = path;

            var searchedFiles = _fileService.SearchFiles(root, name.ToLower());

            return PartialView("SearchFiles",searchedFiles);
        }
        
    }
}