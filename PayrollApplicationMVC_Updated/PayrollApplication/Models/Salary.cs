using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PayrollApplication.Models
{
    public class Salary
    {
        public int SalaryId { get; set; }

        public string SalaryType { get; set; }

        public decimal BasicSalary { get; set; }

        public decimal GrossSalary { get; set; }

        ///Foreign Key
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }


        //nev
        public virtual ICollection<Salary> Salaries { get; set; }

    }

    public enum SalaryType
    {
        Basic = 1,
        Hourly,
        Annually,
        Contactual
    }
}