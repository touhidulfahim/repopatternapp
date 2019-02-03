namespace RepoPattern.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDepartment : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Departments(DepartmentName) VALUES('Administration')");
            Sql("INSERT INTO Departments(DepartmentName) VALUES('Finance')");
            Sql("INSERT INTO Departments(DepartmentName) VALUES('Accounts')");
            Sql("INSERT INTO Departments(DepartmentName) VALUES('Information Technology')");
            Sql("INSERT INTO Departments(DepartmentName) VALUES('Human Resource')");
        }
        
        public override void Down()
        {
        }
    }
}
