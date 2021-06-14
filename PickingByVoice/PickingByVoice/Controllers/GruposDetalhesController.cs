using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PickingByVoice.Models;

namespace PickingByVoice.Controllers
{
    public class GruposDetalhesController : Controller
    {
        private ControleContext db = new ControleContext();

        // GET: GruposDetalhes
        public ActionResult Index()
        {
            var gruposDetalhes = db.GruposDetalhes.Include(g => g.Estudante).Include(g => g.Grupos);
            return View(gruposDetalhes.ToList());
        }

        // GET: GruposDetalhes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GruposDetalhes gruposDetalhes = db.GruposDetalhes.Find(id);
            if (gruposDetalhes == null)
            {
                return HttpNotFound();
            }
            return View(gruposDetalhes);
        }

        // GET: GruposDetalhes/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Usuarios, "UserId", "UserName");
            ViewBag.GrupoId = new SelectList(db.Grupos, "GrupoId", "Descricao");
            return View();
        }

        // POST: GruposDetalhes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GruposDetalhesId,GrupoId,UserId")] GruposDetalhes gruposDetalhes)
        {
            if (ModelState.IsValid)
            {
                db.GruposDetalhes.Add(gruposDetalhes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Usuarios, "UserId", "UserName", gruposDetalhes.UserId);
            ViewBag.GrupoId = new SelectList(db.Grupos, "GrupoId", "Descricao", gruposDetalhes.GrupoId);
            return View(gruposDetalhes);
        }

        // GET: GruposDetalhes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GruposDetalhes gruposDetalhes = db.GruposDetalhes.Find(id);
            if (gruposDetalhes == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Usuarios, "UserId", "UserName", gruposDetalhes.UserId);
            ViewBag.GrupoId = new SelectList(db.Grupos, "GrupoId", "Descricao", gruposDetalhes.GrupoId);
            return View(gruposDetalhes);
        }

        // POST: GruposDetalhes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GruposDetalhesId,GrupoId,UserId")] GruposDetalhes gruposDetalhes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gruposDetalhes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Usuarios, "UserId", "UserName", gruposDetalhes.UserId);
            ViewBag.GrupoId = new SelectList(db.Grupos, "GrupoId", "Descricao", gruposDetalhes.GrupoId);
            return View(gruposDetalhes);
        }

        // GET: GruposDetalhes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GruposDetalhes gruposDetalhes = db.GruposDetalhes.Find(id);
            if (gruposDetalhes == null)
            {
                return HttpNotFound();
            }
            return View(gruposDetalhes);
        }

        // POST: GruposDetalhes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GruposDetalhes gruposDetalhes = db.GruposDetalhes.Find(id);
            db.GruposDetalhes.Remove(gruposDetalhes);
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
