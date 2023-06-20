using Microsoft.Ajax.Utilities;
using PayrollApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace PayrollApplication.ViewModels
{
    public class PayslipViewModel
    {
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public string Position { get; set; }

        public int SalaryId { get; set; }

        public decimal BasicSalary { get; set; }

        public decimal GrossSalary { get; set; }

        public string SalaryOfMonth { get; set; }

        public int TaxId { get; set; }

        public string TaxName { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal NetSalary
        {
            get
            {
                return GrossSalary - TaxAmount;
            }
        }

        //public decimal TotalCompanySalary
        //{
        //    get
        //    {
        //        if (NetSalary > 0)
        //        {
        //            for (int i = 0; i >=1; i++)
        //            {
        //                Console.WriteLine(i);
        //            }
        //            return TotalCompanySalary;
        //        }            
        //    }       
        //}

    }

    
}