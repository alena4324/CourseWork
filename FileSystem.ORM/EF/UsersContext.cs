using FileSystem.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace FileSystem.ORM.EF
{
    public class UsersContext : DbContext
    {
        public UsersContext() : base("UsersContext")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<UsersContext, Migrations.Configuration>());
            //Database.SetInitializer(new UsersDbInitializer());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                        .HasMany<Role>(s => s.Roles)
                        .WithMany(c => c.Users)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("UserRefId");
                            cs.MapRightKey("RoleRefId");
                            cs.ToTable("UserRole");
                        });
        }
    }   
}
