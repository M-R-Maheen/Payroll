namespace PayrollApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCode : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        CompanyType = c.String(),
                        CompanyAddress = c.String(),
                        PhoneNo = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gender = c.String(),
                        ContactNo = c.String(),
                        Email = c.String(),
                        Position = c.String(),
                        Shift = c.String(),
                        Address = c.String(),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        SalaryId = c.Int(nullable: false, identity: true),
                        SalaryType = c.String(),
                        BasicSalary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GrossSalary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EmployeeId = c.Int(nullable: false),
                        Salary_SalaryId = c.Int(),
                    })
                .PrimaryKey(t => t.SalaryId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Salaries", t => t.Salary_SalaryId)
                .Index(t => t.EmployeeId)
                .Index(t => t.Salary_SalaryId);
            
            CreateTable(
                "dbo.Taxes",
                c => new
                    {
                        TaxId = c.Int(nullable: false, identity: true),
                        TaxName = c.String(),
                        TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EmployeeId = c.Int(nullable: false),
                        SalaryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaxId)
                .ForeignKey("dbo.Salaries", t => t.SalaryId, cascadeDelete: true)
                .Index(t => t.SalaryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Taxes", "SalaryId", "dbo.Salaries");
            DropForeignKey("dbo.Salaries", "Salary_SalaryId", "dbo.Salaries");
            DropForeignKey("dbo.Salaries", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Taxes", new[] { "SalaryId" });
            DropIndex("dbo.Salaries", new[] { "Salary_SalaryId" });
            DropIndex("dbo.Salaries", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "CompanyId" });
            DropTable("dbo.Taxes");
            DropTable("dbo.Salaries");
            DropTable("dbo.Employees");
            DropTable("dbo.Companies");
        }
    }
}
