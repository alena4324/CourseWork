using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FileSystem.BusinessLogic.Interface.Models
{
    public class RoleModelBL
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<UserModelBL> Users { get; set; }
    }
}
