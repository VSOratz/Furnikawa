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
    public class InconformidadesController : Controller
    {
        private ColetaContext db = new ColetaContext();

        // GET: Inconformidades
        public ActionResult Index()
        {
            var inconformidades = db.Inconformidades.Include(i => i.ItemColeta);
            return View(inconformidades.ToList());
        }

        // GET: Inconformidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inconformidade inconformidade = db.Inconformidades.Find(id);
            if (inconformidade == null)
            {
                return HttpNotFound();
            }
            return View(inconformidade);
        }

        // GET: Inconformidades/Create
        public ActionResult Create()
        {
            ViewBag.ItemColetaId = new SelectList(db.ItemColeta, "ItemColetaId", "Local_Coleta");
            return View();
        }

        // POST: Inconformidades/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InconformidadeId,InconformidadeSeq,ListaSeq,MaterialCod,QtdeSeparada,DhInconformidade,FgEnviado,ItemColetaId")] Inconformidade inconformidade)
        {
            if (ModelState.IsValid)
            {
                db.Inconformidades.Add(inconformidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemColetaId = new SelectList(db.ItemColeta, "ItemColetaId", "Local_Coleta", inconformidade.ItemColetaId);
            return View(inconformidade);
        }

        // GET: Inconformidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inconformidade inconformidade = db.Inconformidades.Find(id);
            if (inconformidade == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemColetaId = new SelectList(db.ItemColeta, "ItemColetaId", "Local_Coleta", inconformidade.ItemColetaId);
            return View(inconformidade);
        }

        // POST: Inconformidades/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InconformidadeId,InconformidadeSeq,ListaSeq,MaterialCod,QtdeSeparada,DhInconformidade,FgEnviado,ItemColetaId")] Inconformidade inconformidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inconformidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemColetaId = new SelectList(db.ItemColeta, "ItemColetaId", "Local_Coleta", inconformidade.ItemColetaId);
            return View(inconformidade);
        }

        // GET: Inconformidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inconformidade inconformidade = db.Inconformidades.Find(id);
            if (inconformidade == null)
            {
                return HttpNotFound();
            }
            return View(inconformidade);
        }

        // POST: Inconformidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inconformidade inconformidade = db.Inconformidades.Find(id);
            db.Inconformidades.Remove(inconformidade);
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
