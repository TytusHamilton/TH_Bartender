using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BartenderTH.Models;

namespace BartenderTH.Controllers
{
    public class drinksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: drinks
        public ActionResult Index()
        {
            return View(db.drinks.ToList());
        }

        // GET: drinks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            drinks drinks = db.drinks.Find(id);
            if (drinks == null)
            {
                return HttpNotFound();
            }
            return View(drinks);
        }

        // GET: drinks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: drinks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Category,Price")] drinks drinks)
        {
            if (ModelState.IsValid)
            {
                db.drinks.Add(drinks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drinks);
        }

        // GET: drinks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            drinks drinks = db.drinks.Find(id);
            if (drinks == null)
            {
                return HttpNotFound();
            }
            return View(drinks);
        }

        // POST: drinks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Category,Price")] drinks drinks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drinks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drinks);
        }

        // GET: drinks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            drinks drinks = db.drinks.Find(id);
            if (drinks == null)
            {
                return HttpNotFound();
            }
            return View(drinks);
        }

        // POST: drinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            drinks drinks = db.drinks.Find(id);
            db.drinks.Remove(drinks);
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
