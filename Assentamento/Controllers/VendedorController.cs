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
    public class VendedorController : Controller
    {
        private AssentamentoContext db = new AssentamentoContext();

        // GET: /Vendedor/
        public ActionResult Index()
        {
            var vendedor = db.Vendedor.Include(v => v.Cargo).Include(v => v.Empresa);
            return View(vendedor.ToList());
        }

        // GET: /Vendedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendedor vendedor = db.Vendedor.Find(id);
            if (vendedor == null)
            {
                return HttpNotFound();
            }
            return View(vendedor);
        }

        // GET: /Vendedor/Create
        public ActionResult Create()
        {
            ViewBag.IdCargo = new SelectList(db.Cargo, "IdCargo", "Descricao");
            ViewBag.IdEmpresa = new SelectList(db.Empresa, "IdEmpresa", "Nome");
            return View();
        }

        // POST: /Vendedor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IdVendedor,Nome,Cpf,IdCargo,IdEmpresa")] Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                db.Vendedor.Add(vendedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCargo = new SelectList(db.Cargo, "IdCargo", "Descricao", vendedor.IdCargo);
            ViewBag.IdEmpresa = new SelectList(db.Empresa, "IdEmpresa", "Nome", vendedor.IdEmpresa);
            return View(vendedor);
        }

        // GET: /Vendedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendedor vendedor = db.Vendedor.Find(id);
            if (vendedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCargo = new SelectList(db.Cargo, "IdCargo", "Descricao", vendedor.IdCargo);
            ViewBag.IdEmpresa = new SelectList(db.Empresa, "IdEmpresa", "Nome", vendedor.IdEmpresa);
            return View(vendedor);
        }

        // POST: /Vendedor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IdVendedor,Nome,Cpf,IdCargo,IdEmpresa")] Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCargo = new SelectList(db.Cargo, "IdCargo", "Descricao", vendedor.IdCargo);
            ViewBag.IdEmpresa = new SelectList(db.Empresa, "IdEmpresa", "Nome", vendedor.IdEmpresa);
            return View(vendedor);
        }

        // GET: /Vendedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendedor vendedor = db.Vendedor.Find(id);
            if (vendedor == null)
            {
                return HttpNotFound();
            }
            return View(vendedor);
        }

        // POST: /Vendedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vendedor vendedor = db.Vendedor.Find(id);
            db.Vendedor.Remove(vendedor);
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
