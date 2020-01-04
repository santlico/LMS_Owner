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
    public class OwnersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Owners
        public async Task<ActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {

                //jjjjjjj

                return RedirectToAction("Login","Account");
            }
            else
            {
                return View(await db.Owners.ToListAsync());

            }
        }

        // GET: Owners/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owners owners = await db.Owners.FindAsync(id);
            if (owners == null)
            {
                return HttpNotFound();
            }
            return View(owners);
        }

        // GET: Owners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Owners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,OrgName,Email")] Owners owners)
        {
            if (ModelState.IsValid)
            {
                db.Owners.Add(owners);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(owners);
        }

        // GET: Owners/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owners owners = await db.Owners.FindAsync(id);
            if (owners == null)
            {
                return HttpNotFound();
            }
            return View(owners);
        }

        // POST: Owners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,OrgName,Email")] Owners owners)
        {
            if (ModelState.IsValid)
            {
                db.Entry(owners).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(owners);
        }

        // GET: Owners/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owners owners = await db.Owners.FindAsync(id);
            if (owners == null)
            {
                return HttpNotFound();
            }
            return View(owners);
        }

        // POST: Owners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Owners owners = await db.Owners.FindAsync(id);
            db.Owners.Remove(owners);
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
