namespace MadarshoAnalyticsDotNetFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserActions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        ActionId = c.Long(nullable: false),
                        Param1 = c.String(),
                        Param2 = c.String(),
                        Date = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Actions", t => t.ActionId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ActionId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Username = c.String(),
                        AppVersion = c.String(),
                        RegisterDate = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserActions", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserActions", "ActionId", "dbo.Actions");
            DropIndex("dbo.UserActions", new[] { "ActionId" });
            DropIndex("dbo.UserActions", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.UserActions");
            DropTable("dbo.Actions");
        }
    }
}
