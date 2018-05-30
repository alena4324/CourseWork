using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.ORM.Entities
{
    public class User
    {

        [Key]
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

    }

}
