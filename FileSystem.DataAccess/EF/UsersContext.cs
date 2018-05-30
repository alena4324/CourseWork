using FileSystem.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.DataAccess.EF
{
    public class UsersContext : DbContext
    {
        public UsersContext() : base("FileSystemDb")
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }

    public class UserDbInitializer : DropCreateDatabaseAlways<UsersContext>
    {
        protected override void Seed(UsersContext db)
        {
            Role admin = new Role { Name = "admin" };
            Role user = new Role { Name = "user" };
            db.Roles.Add(admin);
            db.Roles.Add(user);
            db.Users.Add(new User
            {
                Login = "admin",
                Password = "123456"
            });
            base.Seed(db);
        }
    }
}
