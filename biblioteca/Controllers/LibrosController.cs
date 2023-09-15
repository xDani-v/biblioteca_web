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
    public class LibrosController : Controller
    {
        private BibliotecaRentaEntities1 db = new BibliotecaRentaEntities1();

        // GET: Libros
        public ActionResult Index()
        {
            var libros = db.Libros.Include(l => l.Autores).Include(l => l.Categorias).Include(l => l.Editoriales).Include(l => l.Lenguajes);
            return View(libros.ToList());
        }

        // GET: Libros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libros libros = db.Libros.Find(id);
            if (libros == null)
            {
                return HttpNotFound();
            }
            return View(libros);
        }

        // GET: Libros/Create
        public ActionResult Create()
        {
            ViewBag.AutorID = new SelectList(db.Autores, "AutorID", "Nombre");
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "NombreCategoria");
            ViewBag.EditorialID = new SelectList(db.Editoriales, "EditorialID", "NombreEditorial");
            ViewBag.LenguajeID = new SelectList(db.Lenguajes, "LenguajeID", "NombreLenguaje");
            return View();
        }

        // POST: Libros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LibroID,Titulo,ISBN,CategoriaID,AutorID,EditorialID,LenguajeID,Stock,Tipo,Precio")] Libros libros)
        {
            if (ModelState.IsValid)
            {
                db.Libros.Add(libros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AutorID = new SelectList(db.Autores, "AutorID", "Nombre", libros.AutorID);
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "NombreCategoria", libros.CategoriaID);
            ViewBag.EditorialID = new SelectList(db.Editoriales, "EditorialID", "NombreEditorial", libros.EditorialID);
            ViewBag.LenguajeID = new SelectList(db.Lenguajes, "LenguajeID", "NombreLenguaje", libros.LenguajeID);
            return View(libros);
        }

        // GET: Libros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libros libros = db.Libros.Find(id);
            if (libros == null)
            {
                return HttpNotFound();
            }
            ViewBag.AutorID = new SelectList(db.Autores, "AutorID", "Nombre", libros.AutorID);
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "NombreCategoria", libros.CategoriaID);
            ViewBag.EditorialID = new SelectList(db.Editoriales, "EditorialID", "NombreEditorial", libros.EditorialID);
            ViewBag.LenguajeID = new SelectList(db.Lenguajes, "LenguajeID", "NombreLenguaje", libros.LenguajeID);
            return View(libros);
        }

        // POST: Libros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LibroID,Titulo,ISBN,CategoriaID,AutorID,EditorialID,LenguajeID,Stock,Tipo,Precio")] Libros libros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libros).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AutorID = new SelectList(db.Autores, "AutorID", "Nombre", libros.AutorID);
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "NombreCategoria", libros.CategoriaID);
            ViewBag.EditorialID = new SelectList(db.Editoriales, "EditorialID", "NombreEditorial", libros.EditorialID);
            ViewBag.LenguajeID = new SelectList(db.Lenguajes, "LenguajeID", "NombreLenguaje", libros.LenguajeID);
            return View(libros);
        }

        // GET: Libros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libros libros = db.Libros.Find(id);
            if (libros == null)
            {
                return HttpNotFound();
            }
            return View(libros);
        }

        // POST: Libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Libros libros = db.Libros.Find(id);
            db.Libros.Remove(libros);
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
