namespace School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedGrades : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Grades", "Teacher_ID", "dbo.Teachers");
            DropIndex("dbo.Grades", new[] { "Teacher_ID" });
            AlterColumn("dbo.Grades", "Teacher_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Grades", "Teacher_ID");
            AddForeignKey("dbo.Grades", "Teacher_ID", "dbo.Teachers", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grades", "Teacher_ID", "dbo.Teachers");
            DropIndex("dbo.Grades", new[] { "Teacher_ID" });
            AlterColumn("dbo.Grades", "Teacher_ID", c => c.Int());
            CreateIndex("dbo.Grades", "Teacher_ID");
            AddForeignKey("dbo.Grades", "Teacher_ID", "dbo.Teachers", "ID");
        }
    }
}
