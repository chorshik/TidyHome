namespace TidyHome2.DAL.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qwerty : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        IdRole = c.Long(nullable: false, identity: true),
                        Role = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.IdRole);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IdUsers = c.Long(nullable: false, identity: true),
                        Surname = c.String(nullable: false, maxLength: 150),
                        Name = c.String(nullable: false, maxLength: 150),
                        Patronymic = c.String(nullable: false, maxLength: 150),
                        Email = c.String(nullable: false, maxLength: 250),
                        Password = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 150),
                        Phone = c.String(nullable: false, maxLength: 12),
                        Discount = c.Int(),
                        IdType = c.Long(),
                    })
                .PrimaryKey(t => t.IdUsers);
            
            CreateTable(
                "dbo.UsersRoles",
                c => new
                    {
                        Users_IdUsers = c.Long(nullable: false),
                        Roles_IdRole = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Users_IdUsers, t.Roles_IdRole })
                .ForeignKey("dbo.Users", t => t.Users_IdUsers)
                .ForeignKey("dbo.Roles", t => t.Roles_IdRole)
                .Index(t => t.Users_IdUsers)
                .Index(t => t.Roles_IdRole);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersRoles", "Roles_IdRole", "dbo.Roles");
            DropForeignKey("dbo.UsersRoles", "Users_IdUsers", "dbo.Users");
            DropIndex("dbo.UsersRoles", new[] { "Roles_IdRole" });
            DropIndex("dbo.UsersRoles", new[] { "Users_IdUsers" });
            DropTable("dbo.UsersRoles");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
        }
    }
}
