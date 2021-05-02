using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using listadoNet.Models;

namespace listadoNet.Controllers
{
    public class NegociosController : Controller
    {
        private BD_PRUEBAEntities1 db = new BD_PRUEBAEntities1();

        // GET: Negocios
        public ActionResult Index()
        {
            return View(db.negocios.ToList());
        }

        // GET: Negocios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            negocios negocios = db.negocios.Find(id);
            if (negocios == null)
            {
                return HttpNotFound();
            }
            return View(negocios);
        }

        // GET: Negocios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Negocios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_negocio,nombre,descripcion,distancia,ruta")] negocios negocios)
        {
            if (ModelState.IsValid)
            {
                db.negocios.Add(negocios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(negocios);
        }

        // GET: Negocios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            negocios negocios = db.negocios.Find(id);
            if (negocios == null)
            {
                return HttpNotFound();
            }
            return View(negocios);
        }

        // POST: Negocios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_negocio,nombre,descripcion,distancia,ruta")] negocios negocios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(negocios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(negocios);
        }

        // GET: Negocios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            negocios negocios = db.negocios.Find(id);
            if (negocios == null)
            {
                return HttpNotFound();
            }
            return View(negocios);
        }

        // POST: Negocios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            negocios negocios = db.negocios.Find(id);
            db.negocios.Remove(negocios);
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
