using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ColetaEntrega.Context;
using ColetaEntrega.Models;

namespace ColetaEntrega.Controllers
{
    public class UsuarioEmpresasController : Controller
    {
        private ColetaContext db = new ColetaContext();

        // GET: UsuarioEmpresas
        public ActionResult Index()
        {
            var usuarioEmpresas = db.UsuarioEmpresas.Include(u => u.Usuario);
            return View(usuarioEmpresas.ToList());
        }

        // GET: UsuarioEmpresas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioEmpresa usuarioEmpresa = db.UsuarioEmpresas.Find(id);
            if (usuarioEmpresa == null)
            {
                return HttpNotFound();
            }
            return View(usuarioEmpresa);
        }

        // GET: UsuarioEmpresas/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Senha");
            return View();
        }

        // POST: UsuarioEmpresas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UsuarioId,ParticipanteId,DhCriacao,NmUsuarioCriou,DhAlteracao,NmUsuarioAlterou")] UsuarioEmpresa usuarioEmpresa)
        {
            if (ModelState.IsValid)
            {
                db.UsuarioEmpresas.Add(usuarioEmpresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Senha", usuarioEmpresa.UsuarioId);
            return View(usuarioEmpresa);
        }

        // GET: UsuarioEmpresas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioEmpresa usuarioEmpresa = db.UsuarioEmpresas.Find(id);
            if (usuarioEmpresa == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Senha", usuarioEmpresa.UsuarioId);
            return View(usuarioEmpresa);
        }

        // POST: UsuarioEmpresas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsuarioId,ParticipanteId,DhCriacao,NmUsuarioCriou,DhAlteracao,NmUsuarioAlterou")] UsuarioEmpresa usuarioEmpresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarioEmpresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Senha", usuarioEmpresa.UsuarioId);
            return View(usuarioEmpresa);
        }

        // GET: UsuarioEmpresas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioEmpresa usuarioEmpresa = db.UsuarioEmpresas.Find(id);
            if (usuarioEmpresa == null)
            {
                return HttpNotFound();
            }
            return View(usuarioEmpresa);
        }

        // POST: UsuarioEmpresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuarioEmpresa usuarioEmpresa = db.UsuarioEmpresas.Find(id);
            db.UsuarioEmpresas.Remove(usuarioEmpresa);
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
