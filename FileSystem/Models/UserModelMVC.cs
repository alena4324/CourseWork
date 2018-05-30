using System.Collections.Generic;

namespace FileSystem.Models
{
    public class UserModelMVC
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<RoleModelMVC> Roles { get; set; }
    }
}