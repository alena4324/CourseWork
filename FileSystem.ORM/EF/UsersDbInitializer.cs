using FileSystem.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.ORM.EF
{
    public class UsersDbInitializer : DropCreateDatabaseAlways<UsersContext>
    {
        protected override void Seed(UsersContext db)
        {
            //Role admin = new Role { Id=1, Name = "admin" };
            //Role user = new Role { Id=2, Name = "user" };
            //db.Roles.Add(admin);
            //db.Roles.Add(user);
            var user = new User() { Login = "admin", Password = "123456" };
            user.Roles.Add(db.Roles.Where(r=>r.Name=="admin").FirstOrDefault());
            db.Users.Add(user);
            base.Seed(db);
        }
    }
}
