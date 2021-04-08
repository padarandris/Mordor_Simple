using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mordor_Simple.Models;

namespace Mordor_Simple.Controllers
{
    public class HordesController : Controller
    {
        private MordorEntities db = new MordorEntities();

        // GET: Hordes
        public ActionResult Index()
        {
            return View(db.Hordes.OrderBy(horde => horde.Name).ToList());
        }

        // GET: Hordes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horde horde = db.Hordes.Find(id);

            if (horde == null)
            {
                return HttpNotFound();
            }


            return View(horde);
        }

        // GET: Hordes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hordes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HordeId,Name")] Horde horde)
        {
            if (ModelState.IsValid)
            {
                db.Hordes.Add(horde);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(horde);
        }

        // GET: Hordes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horde horde = db.Hordes.Find(id);
            if (horde == null)
            {
                return HttpNotFound();
            }
            return View(horde);
        }

        // POST: Hordes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HordeId,Name")] Horde horde)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horde).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(horde);
        }

        // GET: Hordes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horde horde = db.Hordes.Find(id);
            if (horde == null)
            {
                return HttpNotFound();
            }
            return View(horde);
        }

        // POST: Hordes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Horde horde = db.Hordes.Find(id);
            db.Hordes.Remove(horde);
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
