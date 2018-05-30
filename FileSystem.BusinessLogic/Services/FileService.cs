using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSystem.BusinessLogic.Interface.Interfaces;

namespace FileSystem.BusinessLogic.Services
{
    public class FileService : IFileService
    {
        //public DirectoryInfo[] GetAllDirectories(string path)
        //{
        //    if (path == null)
        //        return null;

        //    string root;

        //    if (!path.Contains(":"))
        //        root = path.Insert(1, @":/");
        //    else
        //        root = path;

        //    DirectoryInfo directory = new DirectoryInfo($@"{root}");

        //    if (!directory.Exists)
        //        return null;

        //    var directories = directory.GetDirectories();

        //    return directories;
        //}

        //public FileInfo[] GetAllFiles(string path)
        //{
        //    string root;

        //    if (!path.Contains(":"))
        //        root = path.Insert(1, @":/");
        //    else
        //        root = path;

        //    DirectoryInfo directory = new DirectoryInfo($@"{root}");

        //    if (!directory.Exists)
        //        return null;

        //    var files = directory.GetFiles();

        //    return files;
        //}

        public IEnumerable<FileSystemInfo> GetAllFiles(string path)
        {
            var files = new DirectoryInfo(path).EnumerateFileSystemInfos();

            return files;
        }

        public List<string> GetAllDrives()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            var paths = new List<string>();

            foreach (var drive in allDrives)
            {
                paths.Add(drive.Name.Replace(":", ""));
            }

            return paths;
        }

        public bool CreateFolder(string path, string name)
        {
            //string root;

            //if (!path.Contains(":"))
            //    root = path.Insert(1, @":/");
            //else
            //    root = path;

            string fullPath;

            if (path == null || name == null)
                return false;

            DirectoryInfo directory = new DirectoryInfo(path);

            if (!directory.Exists)
                return false;

            fullPath = String.Concat(path, name);

            if (Directory.Exists(fullPath))
                return false;

            directory.CreateSubdirectory(name);

            return true;
        }

        public bool CreateFile(string path, string name, string type)
        {
            //string root;

            //if (!path.Contains(":"))
            //    root = path.Insert(1, @":/");
            //else
            //    root = path;

            string fullPath;

            if (path == null || name == null)
                return false;

            DirectoryInfo directory = new DirectoryInfo(path);

            if (!directory.Exists)
                return false;

            fullPath = String.Concat(path, "/", name, ".", type);//Path.Combine(root,"/", name,".", type);

            if (File.Exists(fullPath))
                return false;

            File.Create(fullPath);

            return true;
        }

        public bool DeleteFolder(string fullPath)
        {
            //string root;

            //if (!path.Contains(":"))
            //    root = path.Insert(1, @":/");
            //else
            //    root = path;

            if (fullPath != null && Directory.Exists(fullPath))
            {
                Directory.Delete(fullPath);
                return true;
            }

            return false;
        }

        public bool DeleteFile(string path)
        {
            //string fullPath;

            //fullPath = String.Concat(path, ".", type);

            if (path != null && File.Exists(path))
            {
                File.Delete(path);
                return true;
            }

            return false;
        }

        public Dictionary<string, string> SearchFiles(string path, string name)
        {
            Dictionary<string, string> searchedFiles = new Dictionary<string, string>();

            if (String.IsNullOrEmpty(path) || String.IsNullOrEmpty(name))
                return null;

            //Recursion(path, name, searchedFiles);

            Recursion(path, name, searchedFiles);

            return searchedFiles;
        }

        private static void Recursion(string path, string name, Dictionary<string, string> searchedFiles)
        {
            //if (path.Contains(name))
            //    listI.Add(path);
            foreach (var item in new DirectoryInfo(path).GetFiles())
            {
                if (item.Name.ToLower().Contains(name))
                {
                    searchedFiles.Add(item.FullName, "file");
                }
            }
            foreach (var item in new DirectoryInfo(path).GetDirectories("*"))
            {
                if (!item.Attributes.ToString().Contains("Hidden"))
                {
                    if (item.Name.ToLower().Contains(name))
                    {
                        searchedFiles.Add(item.FullName, "folder");
                    }

                    Recursion(item.FullName, name, searchedFiles);
                }
            }
        }

        public bool IsExistPath(string path)
        {
            if(path==null)
                return false;

            FileSystemInfo directory = new DirectoryInfo($@"{path}");

            if (directory.Exists)
                return true;

            return false;
        }

        //public FileSystemInfo[] SortFilesByName(string path, string isAsc)
        //{
        //    if (path == null)
        //        return null;

        //    string root;

        //    if (!path.Contains(":"))
        //        root = path.Insert(1, @":/");
        //    else
        //        root = path;

        //    DirectoryInfo directory = new DirectoryInfo($@"{root}");

        //    FileSystemInfo[] files = directory.GetFileSystemInfos();

        //    if(isAsc=="true")
        //    {
        //        files.OrderBy(f => f.Name);
        //    }
        //    else
        //    {
        //        files.OrderBy(f => f.Name).Reverse();
        //    }

        //    return files;
        //}

        //public FileSystemInfo[] SortFilesByDate(string path, bool isAsc)
        //{
        //    if (path == null)
        //        return null;

        //    string root;

        //    if (!path.Contains(":"))
        //        root = path.Insert(1, @":/");
        //    else
        //        root = path;

        //    DirectoryInfo directory = new DirectoryInfo($@"{root}");

        //    FileSystemInfo[] files = directory.GetFileSystemInfos();

        //    if (isAsc)
        //    {
        //        files.OrderBy(f => f.CreationTime);
        //    }
        //    else
        //    {
        //        files.OrderBy(f => f.CreationTime).Reverse();
        //    }
        //    return files;
        //}

        //public FileSystemInfo[] SortFilesByType(string path, bool isAsc)
        //{
        //    if (path == null)
        //        return null;

        //    string root;

        //    if (!path.Contains(":"))
        //        root = path.Insert(1, @":/");
        //    else
        //        root = path;

        //    DirectoryInfo directory = new DirectoryInfo($@"{root}");

        //    FileSystemInfo[] files = directory.GetFileSystemInfos();

        //    if (isAsc)
        //    {
        //        files.OrderBy(f => f.Extension);
        //    }
        //    else
        //    {
        //        files.OrderBy(f => f.Extension).Reverse();
        //    }
        //    return files;
        //}

    }
}
