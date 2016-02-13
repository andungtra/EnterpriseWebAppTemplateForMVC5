namespace EnterpriseApp.DataAccess.EFContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SmpAuthor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        CreatorId = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        LastEditDate = c.DateTime(nullable: false, precision: 0),
                        LastEditorId = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SmpBook",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        CreatorId = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        LastEditDate = c.DateTime(nullable: false, precision: 0),
                        LastEditorId = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SmpAuthor", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuthorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SmpBook", "AuthorId", "dbo.SmpAuthor");
            DropIndex("dbo.SmpBook", new[] { "AuthorId" });
            DropTable("dbo.SmpBook");
            DropTable("dbo.SmpAuthor");
        }
    }
}
