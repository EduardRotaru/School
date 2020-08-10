namespace School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userChanges3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentModels", "StudentCode", c => c.String());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            DropColumn("dbo.StudentModels", "FirstName");
            DropColumn("dbo.StudentModels", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentModels", "LastName", c => c.String());
            AddColumn("dbo.StudentModels", "FirstName", c => c.String());
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.StudentModels", "StudentCode");
        }
    }
}
