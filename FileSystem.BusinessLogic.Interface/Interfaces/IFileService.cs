using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.BusinessLogic.Interface.Interfaces
{
    public interface IFileService
    {
        //DirectoryInfo[] GetAllDirectories(string path);

        //FileInfo[] GetAllFiles(string path);
        IEnumerable<FileSystemInfo> GetAllFiles(string path);

        List<string> GetAllDrives();

        bool CreateFolder(string path, string name);

        bool CreateFile(string path,  string name, string type);

        bool DeleteFile(string path);

        bool DeleteFolder(string path);

        Dictionary<string, string> SearchFiles(string path, string name);

        bool IsExistPath(string path);

        //FileSystemInfo[] SortFilesByName(string path, string isAsc);

        //FileSystemInfo[] SortFilesByDate(string path, bool isAsc);

        //FileSystemInfo[] SortFilesByType(string path, bool isAsc);
    }
}
