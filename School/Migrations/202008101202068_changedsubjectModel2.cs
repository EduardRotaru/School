namespace School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedsubjectModel2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teachers", "Subject_ID", "dbo.Subjects");
            AddForeignKey("dbo.Teachers", "Subject_ID", "dbo.Subjects", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "Subject_ID", "dbo.Subjects");
            AddForeignKey("dbo.Teachers", "Subject_ID", "dbo.Subjects", "ID", cascadeDelete: true);
        }
    }
}
