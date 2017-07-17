namespace MadarshoAnalyticsDotNetFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firebaseMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "FirebaseToken", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "FirebaseToken");
        }
    }
}
