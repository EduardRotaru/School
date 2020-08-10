namespace School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedEntityNames : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.GradesModels", newName: "Grades");
            RenameTable(name: "dbo.StudentModels", newName: "Students");
            RenameTable(name: "dbo.SubjectModels", newName: "Subjects");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Subjects", newName: "SubjectModels");
            RenameTable(name: "dbo.Students", newName: "StudentModels");
            RenameTable(name: "dbo.Grades", newName: "GradesModels");
        }
    }
}
