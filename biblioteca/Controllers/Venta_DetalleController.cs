using System;
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
    public class Venta_DetalleController : Controller
    {
        private BibliotecaRentaEntities1 db = new BibliotecaRentaEntities1();

        // GET: Venta_Detalle
        public ActionResult Index()
        {
            var venta_Detalle = db.Venta_Detalle.Include(v => v.Libros).Include(v => v.Ventas);
            return View(venta_Detalle.ToList());
        }

        // GET: Venta_Detalle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta_Detalle venta_Detalle = db.Venta_Detalle.Find(id);
            if (venta_Detalle == null)
            {
                return HttpNotFound();
            }
            return View(venta_Detalle);
        }

        // GET: Venta_Detalle/Create
        public ActionResult Create()
        {
            ViewBag.LibroID = new SelectList(db.Libros, "LibroID", "Titulo");
            ViewBag.VentaID = new SelectList(db.Ventas, "VentaID", "VentaID");
            return View();
        }

        // POST: Venta_Detalle/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VentaDetalleID,VentaID,LibroID,Cantidad,Precio")] Venta_Detalle venta_Detalle)
        {
            if (ModelState.IsValid)
            {
                db.Venta_Detalle.Add(venta_Detalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LibroID = new SelectList(db.Libros, "LibroID", "Titulo", venta_Detalle.LibroID);
            ViewBag.VentaID = new SelectList(db.Ventas, "VentaID", "VentaID", venta_Detalle.VentaID);
            return View(venta_Detalle);
        }

        // GET: Venta_Detalle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta_Detalle venta_Detalle = db.Venta_Detalle.Find(id);
            if (venta_Detalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.LibroID = new SelectList(db.Libros, "LibroID", "Titulo", venta_Detalle.LibroID);
            ViewBag.VentaID = new SelectList(db.Ventas, "VentaID", "VentaID", venta_Detalle.VentaID);
            return View(venta_Detalle);
        }

        // POST: Venta_Detalle/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VentaDetalleID,VentaID,LibroID,Cantidad,Precio")] Venta_Detalle venta_Detalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venta_Detalle).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LibroID = new SelectList(db.Libros, "LibroID", "Titulo", venta_Detalle.LibroID);
            ViewBag.VentaID = new SelectList(db.Ventas, "VentaID", "VentaID", venta_Detalle.VentaID);
            return View(venta_Detalle);
        }

        // GET: Venta_Detalle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta_Detalle venta_Detalle = db.Venta_Detalle.Find(id);
            if (venta_Detalle == null)
            {
                return HttpNotFound();
            }
            return View(venta_Detalle);
        }

        // POST: Venta_Detalle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venta_Detalle venta_Detalle = db.Venta_Detalle.Find(id);
            db.Venta_Detalle.Remove(venta_Detalle);
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
