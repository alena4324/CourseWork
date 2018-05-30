using System.Collections.Generic;

namespace FileSystem.BusinessLogic.Interface.Models
{
    public class UserModelBL
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<RoleModelBL> Roles { get; set; }
    }
}
