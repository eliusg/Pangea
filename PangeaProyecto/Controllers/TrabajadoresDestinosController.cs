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
    public class TrabajadoresDestinosController : Controller
    {
        private PangeaEntities db = new PangeaEntities();

        // GET: TrabajadoresDestinos
        public ActionResult Index()
        {
            var trabajadorDestino = db.TrabajadorDestino.Include(t => t.Actividad).Include(t => t.Destino).Include(t => t.Trabajador);
            return View(trabajadorDestino.ToList());
        }

        // GET: TrabajadoresDestinos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrabajadorDestino trabajadorDestino = db.TrabajadorDestino.Find(id);
            if (trabajadorDestino == null)
            {
                return HttpNotFound();
            }
            return View(trabajadorDestino);
        }

        // GET: TrabajadoresDestinos/Create
        public ActionResult Create()
        {
            ViewBag.id_actividad = new SelectList(db.Actividad, "id", "nombre");
            ViewBag.id_destino = new SelectList(db.Destino, "id", "nombre");
            ViewBag.id_trabajador = new SelectList(db.Trabajador, "id", "nombre");
            return View();
        }

        // POST: TrabajadoresDestinos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_destino,id_trabajador,id_actividad,habilitado")] TrabajadorDestino trabajadorDestino)
        {
            if (ModelState.IsValid)
            {
                db.TrabajadorDestino.Add(trabajadorDestino);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_actividad = new SelectList(db.Actividad, "id", "nombre", trabajadorDestino.id_actividad);
            ViewBag.id_destino = new SelectList(db.Destino, "id", "nombre", trabajadorDestino.id_destino);
            ViewBag.id_trabajador = new SelectList(db.Trabajador, "id", "nombre", trabajadorDestino.id_trabajador);
            return View(trabajadorDestino);
        }

        // GET: TrabajadoresDestinos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrabajadorDestino trabajadorDestino = db.TrabajadorDestino.Find(id);
            if (trabajadorDestino == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_actividad = new SelectList(db.Actividad, "id", "nombre", trabajadorDestino.id_actividad);
            ViewBag.id_destino = new SelectList(db.Destino, "id", "nombre", trabajadorDestino.id_destino);
            ViewBag.id_trabajador = new SelectList(db.Trabajador, "id", "nombre", trabajadorDestino.id_trabajador);
            return View(trabajadorDestino);
        }

        // POST: TrabajadoresDestinos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_destino,id_trabajador,id_actividad,habilitado")] TrabajadorDestino trabajadorDestino)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trabajadorDestino).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_actividad = new SelectList(db.Actividad, "id", "nombre", trabajadorDestino.id_actividad);
            ViewBag.id_destino = new SelectList(db.Destino, "id", "nombre", trabajadorDestino.id_destino);
            ViewBag.id_trabajador = new SelectList(db.Trabajador, "id", "nombre", trabajadorDestino.id_trabajador);
            return View(trabajadorDestino);
        }

        // GET: TrabajadoresDestinos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrabajadorDestino trabajadorDestino = db.TrabajadorDestino.Find(id);
            if (trabajadorDestino == null)
            {
                return HttpNotFound();
            }
            return View(trabajadorDestino);
        }

        // POST: TrabajadoresDestinos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrabajadorDestino trabajadorDestino = db.TrabajadorDestino.Find(id);
            db.TrabajadorDestino.Remove(trabajadorDestino);
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
