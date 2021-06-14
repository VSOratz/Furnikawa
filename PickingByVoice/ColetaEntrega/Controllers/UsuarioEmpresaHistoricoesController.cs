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
    public class UsuarioEmpresaHistoricoesController : Controller
    {
        private ColetaContext db = new ColetaContext();

        // GET: UsuarioEmpresaHistoricoes
        public ActionResult Index()
        {
            var usuarioEmpresaHistoricos = db.UsuarioEmpresaHistoricos.Include(u => u.Participante).Include(u => u.Usuario);
            return View(usuarioEmpresaHistoricos.ToList());
        }

        // GET: UsuarioEmpresaHistoricoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioEmpresaHistorico usuarioEmpresaHistorico = db.UsuarioEmpresaHistoricos.Find(id);
            if (usuarioEmpresaHistorico == null)
            {
                return HttpNotFound();
            }
            return View(usuarioEmpresaHistorico);
        }

        // GET: UsuarioEmpresaHistoricoes/Create
        public ActionResult Create()
        {
            ViewBag.ParticipanteId = new SelectList(db.Participantes, "ParticipanteId", "NmRazaoSocial");
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Senha");
            return View();
        }

        // POST: UsuarioEmpresaHistoricoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UsuarioEmpresaHistoricoId,DhInteracao,RotaInteracao,UsuarioId,ParticipanteId")] UsuarioEmpresaHistorico usuarioEmpresaHistorico)
        {
            if (ModelState.IsValid)
            {
                db.UsuarioEmpresaHistoricos.Add(usuarioEmpresaHistorico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ParticipanteId = new SelectList(db.Participantes, "ParticipanteId", "NmRazaoSocial", usuarioEmpresaHistorico.ParticipanteId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Senha", usuarioEmpresaHistorico.UsuarioId);
            return View(usuarioEmpresaHistorico);
        }

        // GET: UsuarioEmpresaHistoricoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioEmpresaHistorico usuarioEmpresaHistorico = db.UsuarioEmpresaHistoricos.Find(id);
            if (usuarioEmpresaHistorico == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParticipanteId = new SelectList(db.Participantes, "ParticipanteId", "NmRazaoSocial", usuarioEmpresaHistorico.ParticipanteId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Senha", usuarioEmpresaHistorico.UsuarioId);
            return View(usuarioEmpresaHistorico);
        }

        // POST: UsuarioEmpresaHistoricoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsuarioEmpresaHistoricoId,DhInteracao,RotaInteracao,UsuarioId,ParticipanteId")] UsuarioEmpresaHistorico usuarioEmpresaHistorico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarioEmpresaHistorico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParticipanteId = new SelectList(db.Participantes, "ParticipanteId", "NmRazaoSocial", usuarioEmpresaHistorico.ParticipanteId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Senha", usuarioEmpresaHistorico.UsuarioId);
            return View(usuarioEmpresaHistorico);
        }

        // GET: UsuarioEmpresaHistoricoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioEmpresaHistorico usuarioEmpresaHistorico = db.UsuarioEmpresaHistoricos.Find(id);
            if (usuarioEmpresaHistorico == null)
            {
                return HttpNotFound();
            }
            return View(usuarioEmpresaHistorico);
        }

        // POST: UsuarioEmpresaHistoricoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuarioEmpresaHistorico usuarioEmpresaHistorico = db.UsuarioEmpresaHistoricos.Find(id);
            db.UsuarioEmpresaHistoricos.Remove(usuarioEmpresaHistorico);
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
