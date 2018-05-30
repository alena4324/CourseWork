using System.Collections.Generic;

namespace FileSystem.Models
{
    public class RoleModelMVC
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<UserModelMVC> Users { get; set; }

    }
}