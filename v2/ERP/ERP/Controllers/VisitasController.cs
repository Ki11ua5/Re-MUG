using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERP.Models;

namespace ERP.Controllers
{
    public class VisitasController : Controller
    {
        private ERPEntities db = new ERPEntities();

        // GET: Visitas
        public ActionResult Index()
        {
            var visitas = db.Visitas.Include(v => v.Empresa1).Include(v => v.Estado1).Include(v => v.Ingeniero1).Include(v => v.Tecnologia1).Include(v => v.TipoVisita);
            return View(visitas.ToList());
        }

        // GET: Visitas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visita visita = db.Visitas.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            return View(visita);
        }

        // GET: Visitas/Create
        public ActionResult Create()
        {
            ViewBag.Empresa = new SelectList(db.Empresas, "id_empresa", "Nombre_Empresa");
            ViewBag.Estado = new SelectList(db.Estadoes, "id_Estado", "Nom_Estado");
            ViewBag.Ingeniero = new SelectList(db.Ingenieroes, "id_ingeniero", "Nombre");
            ViewBag.Tecnologia = new SelectList(db.Tecnologias, "id_Tecnologia", "Nombre_tec");
            ViewBag.Tipo = new SelectList(db.TipoVisitas, "id_tipo_visita", "Nombre_Visita");
            return View();
        }

        // POST: Visitas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Fecha,Costo,Latitud,Altitud,Estado,Empresa,Tecnologia,Tipo,EstatusPago,EstatusCobro,FechaMaxima,Folio,Ingeniero")] Visita visita)
        {
            if (ModelState.IsValid)
            {
                db.Visitas.Add(visita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Empresa = new SelectList(db.Empresas, "id_empresa", "Nombre_Empresa", visita.Empresa);
            ViewBag.Estado = new SelectList(db.Estadoes, "id_Estado", "Nom_Estado", visita.Estado);
            ViewBag.Ingeniero = new SelectList(db.Ingenieroes, "id_ingeniero", "Nombre", visita.Ingeniero);
            ViewBag.Tecnologia = new SelectList(db.Tecnologias, "id_Tecnologia", "Nombre_tec", visita.Tecnologia);
            ViewBag.Tipo = new SelectList(db.TipoVisitas, "id_tipo_visita", "Nombre_Visita", visita.Tipo);
            return View(visita);
        }

        // GET: Visitas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visita visita = db.Visitas.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            ViewBag.Empresa = new SelectList(db.Empresas, "id_empresa", "Nombre_Empresa", visita.Empresa);
            ViewBag.Estado = new SelectList(db.Estadoes, "id_Estado", "Nom_Estado", visita.Estado);
            ViewBag.Ingeniero = new SelectList(db.Ingenieroes, "id_ingeniero", "Nombre", visita.Ingeniero);
            ViewBag.Tecnologia = new SelectList(db.Tecnologias, "id_Tecnologia", "Nombre_tec", visita.Tecnologia);
            ViewBag.Tipo = new SelectList(db.TipoVisitas, "id_tipo_visita", "Nombre_Visita", visita.Tipo);
            return View(visita);
        }

        // POST: Visitas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Fecha,Costo,Latitud,Altitud,Estado,Empresa,Tecnologia,Tipo,EstatusPago,EstatusCobro,FechaMaxima,Folio,Ingeniero")] Visita visita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Empresa = new SelectList(db.Empresas, "id_empresa", "Nombre_Empresa", visita.Empresa);
            ViewBag.Estado = new SelectList(db.Estadoes, "id_Estado", "Nom_Estado", visita.Estado);
            ViewBag.Ingeniero = new SelectList(db.Ingenieroes, "id_ingeniero", "Nombre", visita.Ingeniero);
            ViewBag.Tecnologia = new SelectList(db.Tecnologias, "id_Tecnologia", "Nombre_tec", visita.Tecnologia);
            ViewBag.Tipo = new SelectList(db.TipoVisitas, "id_tipo_visita", "Nombre_Visita", visita.Tipo);
            return View(visita);
        }

        // GET: Visitas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visita visita = db.Visitas.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            return View(visita);
        }

        // POST: Visitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Visita visita = db.Visitas.Find(id);
            db.Visitas.Remove(visita);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult VisitasPagadas()
        {
            var visitas = db.Visitas.Where(v => v.EstatusPago == "Pagada");
            return View(visitas);
        }
        public ActionResult VisitasCobradas()
        {
            var visitas = db.Visitas.Where(v => v.EstatusCobro == "Cobrada");
            return View(visitas);
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
