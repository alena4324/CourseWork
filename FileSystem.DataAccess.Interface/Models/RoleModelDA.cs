using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FileSystem.DataAccess.Interface.Models
{
    public class RoleModelDA
    {

        public int Id { get; set; }


        public string Name { get; set; }

        public virtual ICollection<UserModelDA> Users { get; set; }
    }
}
