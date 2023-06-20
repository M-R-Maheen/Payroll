using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayrollApplication.Models
{
    public class Company
    {
        public Company()
        {
            this.Employees = new List<Employee>();
        }
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string CompanyType { get; set; }

        public string CompanyAddress { get; set;}

        public string PhoneNo  { get; set; }

        public string Email  { get; set; }

        public string Website { get; set; }

        //nev
        public virtual ICollection<Employee> Employees { get; set; }
    }
}