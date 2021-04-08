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
    public class OrcsController : Controller
    {
        private MordorEntities db = new MordorEntities();

        // GET: Orcs
        public ActionResult Index()
        {
            var orcs = db.Orcs.Include(o => o.Horde).Include(o => o.Race).Include(o => o.Weapon).OrderByDescending(orc => orc.KillCount);
            
            return View(orcs.ToList());
        }

        // GET: Orcs/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orc orc = db.Orcs.Find(id);
            if (orc == null)
            {
                return HttpNotFound();
            }
            return View(orc);
        }

        // GET: Orcs/Create
        public ActionResult Create()
        {
            ViewBag.HordeId = new SelectList(db.Hordes, "HordeId", "Name");
            ViewBag.RaceId = new SelectList(db.Races, "RaceId", "Name");
            ViewBag.WeaponId = new SelectList(db.Weapons, "WeaponId", "Name");
            return View();
        }

        // POST: Orcs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrcId,Name,KillCount,RaceId,WeaponId,HordeId")] Orc orc)
        {
            if (ModelState.IsValid)
            {
                db.Orcs.Add(orc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HordeId = new SelectList(db.Hordes, "HordeId", "Name", orc.HordeId);
            ViewBag.RaceId = new SelectList(db.Races, "RaceId", "Name", orc.RaceId);
            ViewBag.WeaponId = new SelectList(db.Weapons, "WeaponId", "Name", orc.WeaponId);
            return View(orc);
        }

        // GET: Orcs/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orc orc = db.Orcs.Find(id);
            if (orc == null)
            {
                return HttpNotFound();
            }
            ViewBag.HordeId = new SelectList(db.Hordes, "HordeId", "Name", orc.HordeId);
            ViewBag.RaceId = new SelectList(db.Races, "RaceId", "Name", orc.RaceId);
            ViewBag.WeaponId = new SelectList(db.Weapons, "WeaponId", "Name", orc.WeaponId);
            return View(orc);
        }

        // POST: Orcs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrcId,Name,KillCount,RaceId,WeaponId,HordeId")] Orc orc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HordeId = new SelectList(db.Hordes, "HordeId", "Name", orc.HordeId);
            ViewBag.RaceId = new SelectList(db.Races, "RaceId", "Name", orc.RaceId);
            ViewBag.WeaponId = new SelectList(db.Weapons, "WeaponId", "Name", orc.WeaponId);
            return View(orc);
        }

        // GET: Orcs/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orc orc = db.Orcs.Find(id);
            if (orc == null)
            {
                return HttpNotFound();
            }
            return View(orc);
        }

        // POST: Orcs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Orc orc = db.Orcs.Find(id);
            db.Orcs.Remove(orc);
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
