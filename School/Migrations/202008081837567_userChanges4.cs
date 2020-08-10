namespace School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userChanges4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Teachers", "FirstName");
            DropColumn("dbo.Teachers", "LastName");
            DropColumn("dbo.Teachers", "BirthDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "BirthDate", c => c.String());
            AddColumn("dbo.Teachers", "LastName", c => c.String());
            AddColumn("dbo.Teachers", "FirstName", c => c.String());
        }
    }
}
