using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class WorkersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Workers
        public async Task<ActionResult> Index()
        {
            return View(await db.Workers.ToListAsync());
        }

        // GET: Workers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workers workers = await db.Workers.FindAsync(id);
            if (workers == null)
            {
                return HttpNotFound();
            }
            return View(workers);
        }

        // GET: Workers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Workers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,FullName,Salary,JobTitle,Email")] Workers workers)
        {
            if (ModelState.IsValid)
            {
                db.Workers.Add(workers);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(workers);
        }

        // GET: Workers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workers workers = await db.Workers.FindAsync(id);
            if (workers == null)
            {
                return HttpNotFound();
            }
            return View(workers);
        }

        // POST: Workers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,FullName,Salary,JobTitle,Email")] Workers workers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workers).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(workers);
        }

        // GET: Workers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workers workers = await db.Workers.FindAsync(id);
            if (workers == null)
            {
                return HttpNotFound();
            }
            return View(workers);
        }

        // POST: Workers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Workers workers = await db.Workers.FindAsync(id);
            db.Workers.Remove(workers);
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
