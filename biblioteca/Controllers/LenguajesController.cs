﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using biblioteca.Models;

namespace biblioteca.Controllers
{
    public class LenguajesController : Controller
    {
        private BibliotecaRentaEntities1 db = new BibliotecaRentaEntities1();

        // GET: Lenguajes
        public ActionResult Index()
        {
            return View(db.Lenguajes.ToList());
        }

        // GET: Lenguajes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lenguajes lenguajes = db.Lenguajes.Find(id);
            if (lenguajes == null)
            {
                return HttpNotFound();
            }
            return View(lenguajes);
        }

        // GET: Lenguajes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lenguajes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LenguajeID,NombreLenguaje")] Lenguajes lenguajes)
        {
            if (ModelState.IsValid)
            {
                db.Lenguajes.Add(lenguajes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lenguajes);
        }

        // GET: Lenguajes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lenguajes lenguajes = db.Lenguajes.Find(id);
            if (lenguajes == null)
            {
                return HttpNotFound();
            }
            return View(lenguajes);
        }

        // POST: Lenguajes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LenguajeID,NombreLenguaje")] Lenguajes lenguajes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lenguajes).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lenguajes);
        }

        // GET: Lenguajes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lenguajes lenguajes = db.Lenguajes.Find(id);
            if (lenguajes == null)
            {
                return HttpNotFound();
            }
            return View(lenguajes);
        }

        // POST: Lenguajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lenguajes lenguajes = db.Lenguajes.Find(id);
            db.Lenguajes.Remove(lenguajes);
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
