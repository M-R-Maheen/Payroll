using PayrollApplication.Models;
using PayrollApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PayrollApplication.Controllers
{
    public class PayslipController : Controller
    {
        private PayrollDbContext db = new PayrollDbContext();


        public ActionResult Index()
        {
           
            var taxlist = db.tblTax.Include(t => t.Salary);
            var emplist = db.tblEmployee;
            var salarylist = db.tblSalary;
            var companylist = db.tblCompany;
            

            var query = from t in taxlist
                        join e in emplist on t.EmployeeId equals e.EmployeeId
                        join c in companylist on e.CompanyId equals c.CompanyId
                        select new PayslipViewModel
                        {
                            TaxId = t.TaxId,
                            TaxName = t.TaxName,
                            TaxAmount = t.TaxAmount,
                            EmployeeName = e.Name,
                            Position = e.Position,
                            SalaryOfMonth = t.Salary.SalaryType,
                            BasicSalary = t.Salary.BasicSalary,
                            GrossSalary = t.Salary.GrossSalary,
                            CompanyName = c.CompanyName,
                            
                        };
            return View(query.ToList());

        }

        // GET: Tax/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tax tax = db.tblTax.Find(id);
            if (tax == null)
            {
                return HttpNotFound();
            }
            return View(tax);
        }
    }
}