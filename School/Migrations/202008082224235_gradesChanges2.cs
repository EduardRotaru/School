namespace School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gradesChanges2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GradesModels", "Date", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GradesModels", "Date");
        }
    }
}
