using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assentamento.Models;

namespace Assentamento.Controllers
{
    public class VisitaController : Controller
    {
        private AssentamentoContext db = new AssentamentoContext();

        // GET: /Visita/
        public ActionResult Index()
        {
            var visita = db.Visita.Include(v => v.Cliente).Include(v => v.Vendedor);
            return View(visita.ToList());
        }

        // GET: /Visita/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visita visita = db.Visita.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            return View(visita);
        }

        // GET: /Visita/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "Nome");
            ViewBag.IdVendedor = new SelectList(db.Vendedor, "IdVendedor", "Nome");
            return View();
        }

        // POST: /Visita/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IdVisita,IdVendedor,IdCliente,Assunto,Descricao")] Visita visita)
        {
            if (ModelState.IsValid)
            {
                db.Visita.Add(visita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "Nome", visita.IdCliente);
            ViewBag.IdVendedor = new SelectList(db.Vendedor, "IdVendedor", "Nome", visita.IdVendedor);
            return View(visita);
        }

        // GET: /Visita/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visita visita = db.Visita.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "Nome", visita.IdCliente);
            ViewBag.IdVendedor = new SelectList(db.Vendedor, "IdVendedor", "Nome", visita.IdVendedor);
            return View(visita);
        }

        // POST: /Visita/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IdVisita,IdVendedor,IdCliente,Assunto,Descricao")] Visita visita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "Nome", visita.IdCliente);
            ViewBag.IdVendedor = new SelectList(db.Vendedor, "IdVendedor", "Nome", visita.IdVendedor);
            return View(visita);
        }

        // GET: /Visita/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visita visita = db.Visita.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            return View(visita);
        }

        // POST: /Visita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Visita visita = db.Visita.Find(id);
            db.Visita.Remove(visita);
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
