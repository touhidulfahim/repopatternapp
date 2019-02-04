namespace RepoPattern.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDepartmentColumninEmployeetable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employee", "DepartmentId");
            AddForeignKey("dbo.Employee", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employee", new[] { "DepartmentId" });
            DropColumn("dbo.Employee", "DepartmentId");
        }
    }
}
