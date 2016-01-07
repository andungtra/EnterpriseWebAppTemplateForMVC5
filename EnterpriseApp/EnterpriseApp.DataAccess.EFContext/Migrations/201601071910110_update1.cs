namespace EnterpriseApp.DataAccess.EFContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogException",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Source = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        Message = c.String(nullable: false, maxLength: 1000, storeType: "nvarchar"),
                        Level = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        IP = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Date = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LogProcess",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ObjectName = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        ObjectPrimaryKey = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Object = c.String(nullable: false, maxLength: 4000, storeType: "nvarchar"),
                        ProcessType = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        IP = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Date = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LogProcess");
            DropTable("dbo.LogException");
        }
    }
}
