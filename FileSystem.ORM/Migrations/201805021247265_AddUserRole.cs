namespace FileSystem.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserRole : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserRefId = c.Int(nullable: false),
                        RoleRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserRefId, t.RoleRefId })
                .ForeignKey("dbo.Users", t => t.UserRefId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleRefId, cascadeDelete: true)
                .Index(t => t.UserRefId)
                .Index(t => t.RoleRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "RoleRefId", "dbo.Roles");
            DropForeignKey("dbo.UserRole", "UserRefId", "dbo.Users");
            DropIndex("dbo.UserRole", new[] { "RoleRefId" });
            DropIndex("dbo.UserRole", new[] { "UserRefId" });
            DropTable("dbo.UserRole");
        }
    }
}
