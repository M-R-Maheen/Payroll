using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using PayrollApplication.Models;

namespace PayrollApplication.Controllers
{
    public class TaxController : Controller
    {
        private PayrollDbContext db = new PayrollDbContext();

        // GET: Tax
        public ActionResult Index()
        {
            var taxlist = db.tblTax.Include(t => t.Salary);
            var emplist = db.tblEmployee;
            var salarylist = db.tblSalary;

            var query = from t in taxlist
                         join e in emplist on t.EmployeeId equals e.EmployeeId
                         select new TaxViewModel
                         {
                             TaxId = t.TaxId,
                             
                             TaxName = t.TaxName,
                             TaxAmount = t.TaxAmount,
                             EmployeeName = e.Name,
                             SalaryName = t.Salary.SalaryType
                         };
            return View(query.ToList());

            //var query = (from a in db1
            //             join b in db2 on a.EnteredBy equals b.UserId
            //             where a.LHManifestNum == LHManifestNum
            //             select new { LHManifestId = a.LHManifestId, LHManifestNum = a.LHManifestNum, LHManifestDate = a.LHManifestDate, StnCode = a.StnCode, Operatr = b.UserName }).FirstOrDefault();
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

        // GET: Tax/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.tblEmployee, "EmployeeId", "Name");
            ViewBag.SalaryId = new SelectList(db.tblSalary, "SalaryId", "SalaryType");
            return View();
        }

        // POST: Tax/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaxId,TaxName,TaxAmount,EmployeeId,SalaryId")] Tax tax, Employee employee)
        {
            if (ModelState.IsValid)
            {
                tax.EmployeeId = employee.EmployeeId;
                db.tblTax.Add(tax);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //add Employee Model Data EmployeeID the Name
            //ViewBag.EmployeeId = new SelectList(db.tblEmployee, "EmployeeId", "Name", employee.EmployeeId);
            ViewBag.SalaryId = new SelectList(db.tblSalary, "SalaryId", "SalaryType", tax.SalaryId);
            return View(tax);
        }

        // GET: Tax/Edit/5
        public ActionResult Edit(int? id)
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

            //ViewBag.EmployeeId = new SelectList(db.tblEmployee, "EmployeeId", "Name");


            ViewBag.EmployeeId = new SelectList(db.tblEmployee, "EmployeeId", "Name",tax.Salary.EmployeeId); 
            ViewBag.SalaryId = new SelectList(db.tblSalary, "SalaryId", "SalaryType", tax.SalaryId);
            return View(tax);
        }

        // POST: Tax/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaxId,TaxName,TaxAmount,EmployeeId,SalaryId")] Tax tax,Employee employee)
        {
            if (ModelState.IsValid)
            {
                tax.EmployeeId = employee.EmployeeId;
                db.Entry(tax).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.EmployeeId = new SelectList(db.tblEmployee, "Employee", "Name", employee.EmployeeId);
            ViewBag.SalaryId = new SelectList(db.tblSalary, "SalaryId", "SalaryType", tax.SalaryId);
            return View(tax);
        }

        // GET: Tax/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Tax/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tax tax = db.tblTax.Find(id);
            db.tblTax.Remove(tax);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
