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
    public class UsuarioController : Controller
    {
        private AssentamentoContext db = new AssentamentoContext();

        // GET: /Usuario/
        public ActionResult Index()
        {
            var usuario = db.Usuario.Include(u => u.Perfil).Include(u => u.Vendedor);
            return View(usuario.ToList());
        }

        // GET: /Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: /Usuario/Create
        public ActionResult Create()
        {
            ViewBag.IdPerfil = new SelectList(db.Perfil, "IdPerfil", "Descricao");
            ViewBag.IdVendedor = new SelectList(db.Vendedor, "IdVendedor", "Nome");
            return View();
        }

        // POST: /Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IdUsuario,Login,Senha,IdPerfil,IdVendedor")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPerfil = new SelectList(db.Perfil, "IdPerfil", "Descricao", usuario.IdPerfil);
            ViewBag.IdVendedor = new SelectList(db.Vendedor, "IdVendedor", "Nome", usuario.IdVendedor);
            return View(usuario);
        }

        // GET: /Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPerfil = new SelectList(db.Perfil, "IdPerfil", "Descricao", usuario.IdPerfil);
            ViewBag.IdVendedor = new SelectList(db.Vendedor, "IdVendedor", "Nome", usuario.IdVendedor);
            return View(usuario);
        }

        // POST: /Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IdUsuario,Login,Senha,IdPerfil,IdVendedor")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPerfil = new SelectList(db.Perfil, "IdPerfil", "Descricao", usuario.IdPerfil);
            ViewBag.IdVendedor = new SelectList(db.Vendedor, "IdVendedor", "Nome", usuario.IdVendedor);
            return View(usuario);
        }

        // GET: /Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: /Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
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
