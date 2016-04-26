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
    public class SolicitudCambioTurnoController : Controller
    {
        private PangeaEntities db = new PangeaEntities();

        // GET: SolicitudCambioTurno
        public ActionResult Index()
        {
            var solicitud_Cambio_Turno = db.Solicitud_Cambio_Turno.Include(s => s.Turno);
            return View(solicitud_Cambio_Turno.ToList());
        }

        // GET: SolicitudCambioTurno/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud_Cambio_Turno solicitud_Cambio_Turno = db.Solicitud_Cambio_Turno.Find(id);
            if (solicitud_Cambio_Turno == null)
            {
                return HttpNotFound();
            }
            return View(solicitud_Cambio_Turno);
        }

        // GET: SolicitudCambioTurno/Create
        public ActionResult Create()
        {
            ViewBag.id_turno = new SelectList(db.Turno, "id", "estado");
            return View();
        }

        // POST: SolicitudCambioTurno/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_turno,estado,id_trabajador_crea,id_trabajador_eval,fecha_crea,fecha_eval,fecha_nueva,id_tipo_turno_nuevo,observacion")] Solicitud_Cambio_Turno solicitud_Cambio_Turno)
        {
            if (ModelState.IsValid)
            {
                db.Solicitud_Cambio_Turno.Add(solicitud_Cambio_Turno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_turno = new SelectList(db.Turno, "id", "estado", solicitud_Cambio_Turno.id_turno);
            return View(solicitud_Cambio_Turno);
        }

        // GET: SolicitudCambioTurno/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud_Cambio_Turno solicitud_Cambio_Turno = db.Solicitud_Cambio_Turno.Find(id);
            if (solicitud_Cambio_Turno == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_turno = new SelectList(db.Turno, "id", "estado", solicitud_Cambio_Turno.id_turno);
            return View(solicitud_Cambio_Turno);
        }

        // POST: SolicitudCambioTurno/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_turno,estado,id_trabajador_crea,id_trabajador_eval,fecha_crea,fecha_eval,fecha_nueva,id_tipo_turno_nuevo,observacion")] Solicitud_Cambio_Turno solicitud_Cambio_Turno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitud_Cambio_Turno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_turno = new SelectList(db.Turno, "id", "estado", solicitud_Cambio_Turno.id_turno);
            return View(solicitud_Cambio_Turno);
        }

        // GET: SolicitudCambioTurno/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud_Cambio_Turno solicitud_Cambio_Turno = db.Solicitud_Cambio_Turno.Find(id);
            if (solicitud_Cambio_Turno == null)
            {
                return HttpNotFound();
            }
            return View(solicitud_Cambio_Turno);
        }

        // POST: SolicitudCambioTurno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Solicitud_Cambio_Turno solicitud_Cambio_Turno = db.Solicitud_Cambio_Turno.Find(id);
            db.Solicitud_Cambio_Turno.Remove(solicitud_Cambio_Turno);
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
