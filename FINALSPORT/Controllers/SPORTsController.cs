using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FINALSPORT.Models;

namespace FINALSPORT.Controllers
{
    public class SPORTsController : Controller
    {
        private SPORTEntities db = new SPORTEntities();

        // GET: SPORTs
        public ActionResult Index()
        {

            return View(db.SPORTs.ToList());
        }

        // GET: SPORTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPORT sPORT = db.SPORTs.Find(id);
            if (sPORT == null)
            {
                return HttpNotFound();
            }
            return View(sPORT);
        }

        // GET: SPORTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SPORTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Sport1,Description")] SPORT sPORT)
        {
            if (ModelState.IsValid)
            {
                db.SPORTs.Add(sPORT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sPORT);
        }

        // GET: SPORTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPORT sPORT = db.SPORTs.Find(id);
            if (sPORT == null)
            {
                return HttpNotFound();
            }
            return View(sPORT);
        }

        // POST: SPORTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Sport1,Description")] SPORT sPORT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sPORT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sPORT);
        }

        // GET: SPORTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPORT sPORT = db.SPORTs.Find(id);
            if (sPORT == null)
            {
                return HttpNotFound();
            }
            return View(sPORT);
        }

        // POST: SPORTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SPORT sPORT = db.SPORTs.Find(id);
            db.SPORTs.Remove(sPORT);
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
