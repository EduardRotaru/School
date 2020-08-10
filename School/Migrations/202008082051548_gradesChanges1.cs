namespace School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gradesChanges1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GradesModels", "Evaluation", c => c.String());
            AddColumn("dbo.GradesModels", "Commentary", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GradesModels", "Commentary");
            DropColumn("dbo.GradesModels", "Evaluation");
        }
    }
}
