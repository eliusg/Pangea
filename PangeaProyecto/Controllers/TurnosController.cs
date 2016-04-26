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
    public class TurnosController : Controller
    {
        private PangeaEntities db = new PangeaEntities();

        // GET: Turnos
        public ActionResult Index()
        {
            var turno = db.Turno.Include(t => t.Tipo_Turno).Include(t => t.Trabajador);
            return View(turno.ToList());
        }

        // GET: Turnos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turno turno = db.Turno.Find(id);
            if (turno == null)
            {
                return HttpNotFound();
            }
            return View(turno);
        }

        // GET: Turnos/Create
        public ActionResult Create()
        {
            ViewBag.id_tipo_turno = new SelectList(db.Tipo_Turno, "id", "nombre");
            ViewBag.id_trabajador_asignado = new SelectList(db.Trabajador, "id", "nombre");
            return View();
        }

        // POST: Turnos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_tipo_turno,fecha,id_sucursal,estado,id_trabajador_asignado,id_trabajador_crea,fecha_crea,id_trabajador_modif,fecha_modif,id_trabajador_elimina,fecha_elimina")] Turno turno)
        {
            if (ModelState.IsValid)
            {
                db.Turno.Add(turno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_tipo_turno = new SelectList(db.Tipo_Turno, "id", "nombre", turno.id_tipo_turno);
            ViewBag.id_trabajador_asignado = new SelectList(db.Trabajador, "id", "nombre", turno.id_trabajador_asignado);
            return View(turno);
        }

        // GET: Turnos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turno turno = db.Turno.Find(id);
            if (turno == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_tipo_turno = new SelectList(db.Tipo_Turno, "id", "nombre", turno.id_tipo_turno);
            ViewBag.id_trabajador_asignado = new SelectList(db.Trabajador, "id", "nombre", turno.id_trabajador_asignado);
            return View(turno);
        }

        // POST: Turnos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_tipo_turno,fecha,id_sucursal,estado,id_trabajador_asignado,id_trabajador_crea,fecha_crea,id_trabajador_modif,fecha_modif,id_trabajador_elimina,fecha_elimina")] Turno turno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(turno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_tipo_turno = new SelectList(db.Tipo_Turno, "id", "nombre", turno.id_tipo_turno);
            ViewBag.id_trabajador_asignado = new SelectList(db.Trabajador, "id", "nombre", turno.id_trabajador_asignado);
            return View(turno);
        }

        // GET: Turnos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turno turno = db.Turno.Find(id);
            if (turno == null)
            {
                return HttpNotFound();
            }
            return View(turno);
        }

        // POST: Turnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Turno turno = db.Turno.Find(id);
            db.Turno.Remove(turno);
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
