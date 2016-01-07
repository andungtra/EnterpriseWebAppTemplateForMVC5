namespace EnterpriseApp.DataAccess.EFContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IDRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Name = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.IDUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        RoleId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.IDRole", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.IDUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.IDUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        CreatorId = c.String(nullable: false, unicode: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        LastEditorId = c.String(nullable: false, unicode: false),
                        LastEditDate = c.DateTime(nullable: false, precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256, storeType: "nvarchar"),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(unicode: false),
                        SecurityStamp = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 0),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.IDUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ClaimType = c.String(unicode: false),
                        ClaimValue = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IDUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.IDUserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ProviderKey = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.IDUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IDUserRole", "UserId", "dbo.IDUser");
            DropForeignKey("dbo.IDUserLogin", "UserId", "dbo.IDUser");
            DropForeignKey("dbo.IDUserClaim", "UserId", "dbo.IDUser");
            DropForeignKey("dbo.IDUserRole", "RoleId", "dbo.IDRole");
            DropIndex("dbo.IDUserLogin", new[] { "UserId" });
            DropIndex("dbo.IDUserClaim", new[] { "UserId" });
            DropIndex("dbo.IDUser", "UserNameIndex");
            DropIndex("dbo.IDUserRole", new[] { "RoleId" });
            DropIndex("dbo.IDUserRole", new[] { "UserId" });
            DropIndex("dbo.IDRole", "RoleNameIndex");
            DropTable("dbo.IDUserLogin");
            DropTable("dbo.IDUserClaim");
            DropTable("dbo.IDUser");
            DropTable("dbo.IDUserRole");
            DropTable("dbo.IDRole");
        }
    }
}
