namespace School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userChanges5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "BirthDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "BirthDate");
        }
    }
}
