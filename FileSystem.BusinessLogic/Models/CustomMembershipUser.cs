using FileSystem.BusinessLogic.Interface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace FileSystem.BusinessLogic.Models
{
    public class CustomMembershipUser: MembershipUser
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public ICollection<RoleModelBL> Roles { get; set; }


        public CustomMembershipUser(UserModelBL user) : base("CustomMembershipProvider", user.Login, user.Id, string.Empty, string.Empty, string.Empty, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now)
        {
            UserId = user.Id;
            Login = user.Login;
            Password = user.Password;
            Roles = user.Roles;
        }
    }
}
