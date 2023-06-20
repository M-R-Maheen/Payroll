using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PayrollApplication.Models
{
    public class Employee
    {
        public Employee()
        {
            this.Salaries = new List<Salary>();
        }
        public int EmployeeId { get; set; }

        public String Name { get; set; }

        public String Gender { get; set; }

        public String ContactNo { get; set; }

        public String Email { get; set; }

        public String Position { get; set; }

        public String Shift { get; set; }

        public String Address { get; set; }

        ///Foreign Key
        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        //Nev
        public List<Salary> Salaries { get; set; }




    }
    public enum Gender
    {
        Male = 1,
        Female,
        Other

    }

    public enum Shift
    {
        Morning = 1,
        Day,
        Evening

    }

    public enum Position
    {
        CEO = 1,
        Developer,
        Accountant,
        Staff
    }

}