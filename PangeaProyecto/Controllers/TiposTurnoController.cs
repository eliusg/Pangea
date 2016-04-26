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
    public class TiposTurnoController : Controller
    {
        private PangeaEntities db = new PangeaEntities();

        // GET: TiposTurno
        public ActionResult Index()
        {
            return View(db.Tipo_Turno.ToList());
        }

        // GET: TiposTurno/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Turno tipo_Turno = db.Tipo_Turno.Find(id);
            if (tipo_Turno == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Turno);
        }

        // GET: TiposTurno/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposTurno/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,hora_inicio,hora_fin,habilitado")] Tipo_Turno tipo_Turno)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_Turno.Add(tipo_Turno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_Turno);
        }

        // GET: TiposTurno/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Turno tipo_Turno = db.Tipo_Turno.Find(id);
            if (tipo_Turno == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Turno);
        }

        // POST: TiposTurno/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,hora_inicio,hora_fin,habilitado")] Tipo_Turno tipo_Turno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_Turno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_Turno);
        }

        // GET: TiposTurno/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Turno tipo_Turno = db.Tipo_Turno.Find(id);
            if (tipo_Turno == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Turno);
        }

        // POST: TiposTurno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_Turno tipo_Turno = db.Tipo_Turno.Find(id);
            db.Tipo_Turno.Remove(tipo_Turno);
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
