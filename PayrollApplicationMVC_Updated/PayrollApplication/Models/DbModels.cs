using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PayrollApplication.Models
{
    public class PayrollDbContext : DbContext
    {
        public PayrollDbContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PayrollDbContext>());
        }
        public DbSet<Company> tblCompany { get; set; }
        public DbSet<Employee> tblEmployee { get; set; }
        public DbSet<Salary> tblSalary { get; set; }
        public DbSet<Tax> tblTax { get; set; }

    }
}