using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Oracle_And_ASPNET_MVC.Models;

namespace Oracle_And_ASPNET_MVC.Controllers
{
    public class EMPLOYEEsController : Controller
    {
        private HRModel db = new HRModel();

        // GET: EMPLOYEEs
        public async Task<ActionResult> Index()
        {
            db.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            var eMPLOYEES = db.EMPLOYEES.Include(e => e.MANAGER); //.Include(e => e.DEPARTMENT).Include(e => e.JOB);
            return View(await eMPLOYEES.ToListAsync());
        }

        // GET: EMPLOYEEs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEE eMPLOYEE = await db.EMPLOYEES.FindAsync(id);
            if (eMPLOYEE == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYEE);
        }

        // GET: EMPLOYEEs/Create
        public ActionResult Create()
        {
            ViewBag.DEPARTMENT_ID = new SelectList(db.DEPARTMENTS, "DEPARTMENT_ID", "DEPARTMENT_NAME");
            ViewBag.MANAGER_ID = new SelectList(db.EMPLOYEES, "EMPLOYEE_ID", "FIRST_NAME");
            ViewBag.JOB_ID = new SelectList(db.JOBS, "JOB_ID", "JOB_TITLE");
            return View();
        }

        // POST: EMPLOYEEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EMPLOYEE_ID,FIRST_NAME,LAST_NAME,EMAIL,PHONE_NUMBER,HIRE_DATE,JOB_ID,SALARY,COMMISSION_PCT,MANAGER_ID,DEPARTMENT_ID")] EMPLOYEE eMPLOYEE)
        {
            if (ModelState.IsValid)
            {
                db.EMPLOYEES.Add(eMPLOYEE);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DEPARTMENT_ID = new SelectList(db.DEPARTMENTS, "DEPARTMENT_ID", "DEPARTMENT_NAME", eMPLOYEE.DEPARTMENT_ID);
            ViewBag.MANAGER_ID = new SelectList(db.EMPLOYEES, "EMPLOYEE_ID", "FIRST_NAME", eMPLOYEE.MANAGER_ID);
            ViewBag.JOB_ID = new SelectList(db.JOBS, "JOB_ID", "JOB_TITLE", eMPLOYEE.JOB_ID);
            return View(eMPLOYEE);
        }

        // GET: EMPLOYEEs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEE eMPLOYEE = await db.EMPLOYEES.FindAsync(id);
            if (eMPLOYEE == null)
            {
                return HttpNotFound();
            }
            ViewBag.DEPARTMENT_ID = new SelectList(db.DEPARTMENTS, "DEPARTMENT_ID", "DEPARTMENT_NAME", eMPLOYEE.DEPARTMENT_ID);
            ViewBag.MANAGER_ID = new SelectList(db.EMPLOYEES, "EMPLOYEE_ID", "FIRST_NAME", eMPLOYEE.MANAGER_ID);
            ViewBag.JOB_ID = new SelectList(db.JOBS, "JOB_ID", "JOB_TITLE", eMPLOYEE.JOB_ID);
            return View(eMPLOYEE);
        }

        // POST: EMPLOYEEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EMPLOYEE_ID,FIRST_NAME,LAST_NAME,EMAIL,PHONE_NUMBER,HIRE_DATE,JOB_ID,SALARY,COMMISSION_PCT,MANAGER_ID,DEPARTMENT_ID")] EMPLOYEE eMPLOYEE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPLOYEE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DEPARTMENT_ID = new SelectList(db.DEPARTMENTS, "DEPARTMENT_ID", "DEPARTMENT_NAME", eMPLOYEE.DEPARTMENT_ID);
            ViewBag.MANAGER_ID = new SelectList(db.EMPLOYEES, "EMPLOYEE_ID", "FIRST_NAME", eMPLOYEE.MANAGER_ID);
            ViewBag.JOB_ID = new SelectList(db.JOBS, "JOB_ID", "JOB_TITLE", eMPLOYEE.JOB_ID);
            return View(eMPLOYEE);
        }

        // GET: EMPLOYEEs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEE eMPLOYEE = await db.EMPLOYEES.FindAsync(id);
            if (eMPLOYEE == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYEE);
        }

        // POST: EMPLOYEEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EMPLOYEE eMPLOYEE = await db.EMPLOYEES.FindAsync(id);
            db.EMPLOYEES.Remove(eMPLOYEE);
            await db.SaveChangesAsync();
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
