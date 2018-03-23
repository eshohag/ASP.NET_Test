namespace ASP.NET_Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialRelation : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Activities", "StudentId");
            CreateIndex("dbo.Activities", "DaysId");
            AddForeignKey("dbo.Activities", "DaysId", "dbo.Days", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Activities", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Activities", "DaysId", "dbo.Days");
            DropIndex("dbo.Activities", new[] { "DaysId" });
            DropIndex("dbo.Activities", new[] { "StudentId" });
        }
    }
}
