namespace School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gradesChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GradesModels", "Student_ID", c => c.Int());
            AddColumn("dbo.GradesModels", "Subject_ID", c => c.Int());
            AddColumn("dbo.GradesModels", "Teacher_ID", c => c.Int());
            CreateIndex("dbo.GradesModels", "Student_ID");
            CreateIndex("dbo.GradesModels", "Subject_ID");
            CreateIndex("dbo.GradesModels", "Teacher_ID");
            AddForeignKey("dbo.GradesModels", "Student_ID", "dbo.StudentModels", "ID");
            AddForeignKey("dbo.GradesModels", "Subject_ID", "dbo.SubjectModels", "ID");
            AddForeignKey("dbo.GradesModels", "Teacher_ID", "dbo.Teachers", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GradesModels", "Teacher_ID", "dbo.Teachers");
            DropForeignKey("dbo.GradesModels", "Subject_ID", "dbo.SubjectModels");
            DropForeignKey("dbo.GradesModels", "Student_ID", "dbo.StudentModels");
            DropIndex("dbo.GradesModels", new[] { "Teacher_ID" });
            DropIndex("dbo.GradesModels", new[] { "Subject_ID" });
            DropIndex("dbo.GradesModels", new[] { "Student_ID" });
            DropColumn("dbo.GradesModels", "Teacher_ID");
            DropColumn("dbo.GradesModels", "Subject_ID");
            DropColumn("dbo.GradesModels", "Student_ID");
        }
    }
}
