namespace School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedteacher : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teachers", "Subject_ID1", "dbo.Subjects");
            DropForeignKey("dbo.Teachers", "FK_dbo.Teachers_dbo.SubjectModels_Subject_ID");
            DropIndex("dbo.Teachers", new[] { "Subject_ID1" });
            DropColumn("dbo.Teachers", "Subject_ID");
            RenameColumn(table: "dbo.Teachers", name: "Subject_ID1", newName: "Subject_ID");
            AlterColumn("dbo.Teachers", "Subject_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Teachers", "Subject_ID");
            AddForeignKey("dbo.Teachers", "Subject_ID", "dbo.Subjects", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "FK_dbo.Teachers_dbo.SubjectModels_Subject_ID");
            DropForeignKey("dbo.Teachers", "Subject_ID", "dbo.Subjects");
            DropIndex("dbo.Teachers", new[] { "Subject_ID" });
            AlterColumn("dbo.Teachers", "Subject_ID", c => c.Int());
            RenameColumn(table: "dbo.Teachers", name: "Subject_ID", newName: "Subject_ID1");
            AddColumn("dbo.Teachers", "Subject_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Teachers", "Subject_ID1");
            AddForeignKey("dbo.Teachers", "Subject_ID1", "dbo.Subjects", "ID");
        }
    }
}
