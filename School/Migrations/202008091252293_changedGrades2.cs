namespace School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedGrades2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Grades", "Student_ID", "dbo.Students");
            DropIndex("dbo.Grades", new[] { "Student_ID" });
            AlterColumn("dbo.Grades", "Student_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Grades", "Student_ID");
            AddForeignKey("dbo.Grades", "Student_ID", "dbo.Students", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grades", "Student_ID", "dbo.Students");
            DropIndex("dbo.Grades", new[] { "Student_ID" });
            AlterColumn("dbo.Grades", "Student_ID", c => c.Int());
            CreateIndex("dbo.Grades", "Student_ID");
            AddForeignKey("dbo.Grades", "Student_ID", "dbo.Students", "ID");
        }
    }
}
