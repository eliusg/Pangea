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
    public class SolicitudAusenciaController : Controller
    {
        private PangeaEntities db = new PangeaEntities();

        // GET: SolicitudAusencia
        public ActionResult Index()
        {
            var solicitud_Ausencia = db.Solicitud_Ausencia.Include(s => s.Trabajador);
            return View(solicitud_Ausencia.ToList());
        }

        // GET: SolicitudAusencia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud_Ausencia solicitud_Ausencia = db.Solicitud_Ausencia.Find(id);
            if (solicitud_Ausencia == null)
            {
                return HttpNotFound();
            }
            return View(solicitud_Ausencia);
        }

        // GET: SolicitudAusencia/Create
        public ActionResult Create()
        {
            ViewBag.id_trabajador_crea = new SelectList(db.Trabajador, "id", "nombre");
            return View();
        }

        // POST: SolicitudAusencia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,estado,fecha_inicial_aus,fecha_final_aus,tipo_ausencia,id_trabajador_eval,fecha_eval,id_turno,id_trabajador_crea,fecha_crea,id_trabajador_modif,fecha_modif,observacion")] Solicitud_Ausencia solicitud_Ausencia)
        {
            if (ModelState.IsValid)
            {
                db.Solicitud_Ausencia.Add(solicitud_Ausencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_trabajador_crea = new SelectList(db.Trabajador, "id", "nombre", solicitud_Ausencia.id_trabajador_crea);
            return View(solicitud_Ausencia);
        }

        // GET: SolicitudAusencia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud_Ausencia solicitud_Ausencia = db.Solicitud_Ausencia.Find(id);
            if (solicitud_Ausencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_trabajador_crea = new SelectList(db.Trabajador, "id", "nombre", solicitud_Ausencia.id_trabajador_crea);
            return View(solicitud_Ausencia);
        }

        // POST: SolicitudAusencia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,estado,fecha_inicial_aus,fecha_final_aus,tipo_ausencia,id_trabajador_eval,fecha_eval,id_turno,id_trabajador_crea,fecha_crea,id_trabajador_modif,fecha_modif,observacion")] Solicitud_Ausencia solicitud_Ausencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitud_Ausencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_trabajador_crea = new SelectList(db.Trabajador, "id", "nombre", solicitud_Ausencia.id_trabajador_crea);
            return View(solicitud_Ausencia);
        }

        // GET: SolicitudAusencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud_Ausencia solicitud_Ausencia = db.Solicitud_Ausencia.Find(id);
            if (solicitud_Ausencia == null)
            {
                return HttpNotFound();
            }
            return View(solicitud_Ausencia);
        }

        // POST: SolicitudAusencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Solicitud_Ausencia solicitud_Ausencia = db.Solicitud_Ausencia.Find(id);
            db.Solicitud_Ausencia.Remove(solicitud_Ausencia);
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
