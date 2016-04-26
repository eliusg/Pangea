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
    public class TrabajadoresController : Controller
    {
        private PangeaEntities db = new PangeaEntities();

        // GET: Trabajadores
        public ActionResult Index()
        {
            var trabajador = db.Trabajador.Include(t => t.Rol).Include(t => t.Sucursal);
            return View(trabajador.ToList());
        }

        // GET: Trabajadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajador trabajador = db.Trabajador.Find(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            return View(trabajador);
        }

        // GET: Trabajadores/Create
        public ActionResult Create()
        {
            ViewBag.id_rol = new SelectList(db.Rol, "id", "nombre");
            ViewBag.id_sucursal = new SelectList(db.Sucursal, "id", "nombre");
            return View();
        }

        // POST: Trabajadores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_rol,id_sucursal,nombre,apellido1,apellido2,telefono,telefono2,habilitado,id_trabajador_crea,fecha_crea,id_trabajador_modif,fecha_modif,id_usuario")] Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                db.Trabajador.Add(trabajador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_rol = new SelectList(db.Rol, "id", "nombre", trabajador.id_rol);
            ViewBag.id_sucursal = new SelectList(db.Sucursal, "id", "nombre", trabajador.id_sucursal);
            return View(trabajador);
        }

        // GET: Trabajadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajador trabajador = db.Trabajador.Find(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_rol = new SelectList(db.Rol, "id", "nombre", trabajador.id_rol);
            ViewBag.id_sucursal = new SelectList(db.Sucursal, "id", "nombre", trabajador.id_sucursal);
            return View(trabajador);
        }

        // POST: Trabajadores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_rol,id_sucursal,nombre,apellido1,apellido2,telefono,telefono2,habilitado,id_trabajador_crea,fecha_crea,id_trabajador_modif,fecha_modif,id_usuario")] Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trabajador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_rol = new SelectList(db.Rol, "id", "nombre", trabajador.id_rol);
            ViewBag.id_sucursal = new SelectList(db.Sucursal, "id", "nombre", trabajador.id_sucursal);
            return View(trabajador);
        }

        // GET: Trabajadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajador trabajador = db.Trabajador.Find(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            return View(trabajador);
        }

        // POST: Trabajadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trabajador trabajador = db.Trabajador.Find(id);
            db.Trabajador.Remove(trabajador);
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
