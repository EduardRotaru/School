namespace School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedsubjectModel : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Teachers", new[] { "Subject_ID" });
            AlterColumn("dbo.Teachers", "Subject_ID", c => c.Int());
            CreateIndex("dbo.Teachers", "Subject_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Teachers", new[] { "Subject_ID" });
            AlterColumn("dbo.Teachers", "Subject_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Teachers", "Subject_ID");
        }
    }
}
