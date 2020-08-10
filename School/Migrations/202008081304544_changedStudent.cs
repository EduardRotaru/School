namespace School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentModels", "FirstName", c => c.String());
            AddColumn("dbo.StudentModels", "LastName", c => c.String());
            DropColumn("dbo.StudentModels", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentModels", "Name", c => c.String());
            DropColumn("dbo.StudentModels", "LastName");
            DropColumn("dbo.StudentModels", "FirstName");
        }
    }
}
