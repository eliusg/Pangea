using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PangeaProyecto.Datos;

namespace PangeaProyecto.Controllers
{
    public class PresenciasController : Controller
    {
        private PangeaEntities db = new PangeaEntities();

        // GET: Presencias
        public ActionResult Index()
        {
            var presencia = db.Presencia.Include(p => p.Turno);
            return View(presencia.ToList());
        }

        // GET: Presencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Presencia presencia = db.Presencia.Find(id);
            if (presencia == null)
            {
                return HttpNotFound();
            }
            return View(presencia);
        }

        // GET: Presencias/Create
        public ActionResult Create()
        {
            ViewBag.id_turno = new SelectList(db.Turno, "id", "estado");
            return View();
        }

        // POST: Presencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_turno,inicio,fin,id_trabajador_crea,fecha_crea")] Presencia presencia)
        {
            if (ModelState.IsValid)
            {
                db.Presencia.Add(presencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_turno = new SelectList(db.Turno, "id", "estado", presencia.id_turno);
            return View(presencia);
        }

        // GET: Presencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Presencia presencia = db.Presencia.Find(id);
            if (presencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_turno = new SelectList(db.Turno, "id", "estado", presencia.id_turno);
            return View(presencia);
        }

        // POST: Presencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_turno,inicio,fin,id_trabajador_crea,fecha_crea")] Presencia presencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(presencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_turno = new SelectList(db.Turno, "id", "estado", presencia.id_turno);
            return View(presencia);
        }

        // GET: Presencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Presencia presencia = db.Presencia.Find(id);
            if (presencia == null)
            {
                return HttpNotFound();
            }
            return View(presencia);
        }

        // POST: Presencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Presencia presencia = db.Presencia.Find(id);
            db.Presencia.Remove(presencia);
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
