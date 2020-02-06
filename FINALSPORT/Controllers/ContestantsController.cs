using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FINALSPORT.Models;

namespace FINALSPORT.Views
{
    public class ContestantsController : Controller
    {
        private SPORTEntities db = new SPORTEntities();

        // GET: Contestants
        public ActionResult Index(int ID)
        {
            var contestants = db.Contestants.Where(p => p.SportID == ID);
            return View(contestants.ToList());
        }

        // GET: Contestants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contestant contestant = db.Contestants.Find(id);
            if (contestant == null)
            {
                return HttpNotFound();
            }
            return View(contestant);
        }

        // GET: Contestants/Create
        public ActionResult Create()
        {
            ViewBag.SportID = new SelectList(db.SPORTs, "ID", "Sport1");
            return View();
        }

        // POST: Contestants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FullName,Age,Country,SportID")] Contestant contestant)
        {
            if (ModelState.IsValid)
            {
                db.Contestants.Add(contestant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SportID = new SelectList(db.SPORTs, "ID", "Sport1", contestant.SportID);
            return View(contestant);
        }

        // GET: Contestants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contestant contestant = db.Contestants.Find(id);
            if (contestant == null)
            {
                return HttpNotFound();
            }
            ViewBag.SportID = new SelectList(db.SPORTs, "ID", "Sport1", contestant.SportID);
            return View(contestant);
        }

        // POST: Contestants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FullName,Age,Country,SportID")] Contestant contestant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contestant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SportID = new SelectList(db.SPORTs, "ID", "Sport1", contestant.SportID);
            return View(contestant);
        }

        // GET: Contestants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contestant contestant = db.Contestants.Find(id);
            if (contestant == null)
            {
                return HttpNotFound();
            }
            return View(contestant);
        }

        // POST: Contestants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contestant contestant = db.Contestants.Find(id);
            db.Contestants.Remove(contestant);
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
