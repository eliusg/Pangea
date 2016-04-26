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
    public class AusenciasController : Controller
    {
        private PangeaEntities db = new PangeaEntities();

        // GET: Ausencias
        public ActionResult Index()
        {
            var ausencia = db.Ausencia.Include(a => a.Trabajador);
            return View(ausencia.ToList());
        }

        // GET: Ausencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ausencia ausencia = db.Ausencia.Find(id);
            if (ausencia == null)
            {
                return HttpNotFound();
            }
            return View(ausencia);
        }

        // GET: Ausencias/Create
        public ActionResult Create()
        {
            ViewBag.id_trabajador_crea = new SelectList(db.Trabajador, "id", "nombre");
            return View();
        }

        // POST: Ausencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,inicio,fin,tipo_ausencia,id_trabajador_ausente,id_turno,id_solicitud,id_trabajador_crea,fecha_crea,id_trabajador_modif,fecha_modif")] Ausencia ausencia)
        {
            if (ModelState.IsValid)
            {
                db.Ausencia.Add(ausencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_trabajador_crea = new SelectList(db.Trabajador, "id", "nombre", ausencia.id_trabajador_crea);
            return View(ausencia);
        }

        // GET: Ausencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ausencia ausencia = db.Ausencia.Find(id);
            if (ausencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_trabajador_crea = new SelectList(db.Trabajador, "id", "nombre", ausencia.id_trabajador_crea);
            return View(ausencia);
        }

        // POST: Ausencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,inicio,fin,tipo_ausencia,id_trabajador_ausente,id_turno,id_solicitud,id_trabajador_crea,fecha_crea,id_trabajador_modif,fecha_modif")] Ausencia ausencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ausencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_trabajador_crea = new SelectList(db.Trabajador, "id", "nombre", ausencia.id_trabajador_crea);
            return View(ausencia);
        }

        // GET: Ausencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ausencia ausencia = db.Ausencia.Find(id);
            if (ausencia == null)
            {
                return HttpNotFound();
            }
            return View(ausencia);
        }

        // POST: Ausencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ausencia ausencia = db.Ausencia.Find(id);
            db.Ausencia.Remove(ausencia);
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
