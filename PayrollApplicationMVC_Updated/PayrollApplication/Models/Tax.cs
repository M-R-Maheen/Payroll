using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PayrollApplication.Models
{
    public class Tax
    {
        public int TaxId { get; set; }

        public string TaxName { get; set; }

        public decimal TaxAmount { get; set; }

        public int EmployeeId { get; set; }

        [ForeignKey("Salary")]
        public int SalaryId { get; set; }

        public virtual Salary Salary { get; set; }

    }

    public class TaxViewModel
    {
        public int TaxId { get; set; }

        public string TaxName { get; set; }

        public decimal TaxAmount { get; set; }

        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public string SalaryName { get; set; }

        //[ForeignKey("Salary")]
        //public int SalaryId { get; set; }

       // public virtual Salary Salary { get; set; }
    }
}