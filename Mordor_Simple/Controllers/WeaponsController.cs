﻿using System;
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
    public class WeaponsController : Controller
    {
        private MordorEntities db = new MordorEntities();

        // GET: Weapons
        public ActionResult Index()
        {
            return View(db.Weapons.OrderBy(weapon => weapon.Name).ToList());
        }

        // GET: Weapons/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weapon weapon = db.Weapons.Find(id);
            if (weapon == null)
            {
                return HttpNotFound();
            }
            return View(weapon);
        }

        // GET: Weapons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Weapons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WeaponId,Name")] Weapon weapon)
        {
            if (ModelState.IsValid)
            {
                db.Weapons.Add(weapon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(weapon);
        }

        // GET: Weapons/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weapon weapon = db.Weapons.Find(id);
            if (weapon == null)
            {
                return HttpNotFound();
            }
            return View(weapon);
        }

        // POST: Weapons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WeaponId,Name")] Weapon weapon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weapon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(weapon);
        }

        // GET: Weapons/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weapon weapon = db.Weapons.Find(id);
            if (weapon == null)
            {
                return HttpNotFound();
            }
            return View(weapon);
        }

        // POST: Weapons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Weapon weapon = db.Weapons.Find(id);
            db.Weapons.Remove(weapon);
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
