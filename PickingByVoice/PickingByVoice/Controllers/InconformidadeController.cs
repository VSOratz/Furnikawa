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
    public class InconformidadeController : Controller
    {
        private ControleContext db = new ControleContext();

        // GET: Inconformidade
        public ActionResult Index()
        {
            return View(db.Inconformidades.ToList());
        }

        // GET: Inconformidade/Details/5
        public ActionResult Details(long? id)
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

        // GET: Inconformidade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inconformidade/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InconformidadeId,InconformidadeSeq,ListaSeq,MaterialCod,QtdeSeparada,DhInconformidade,FgEnviado")] Inconformidade inconformidade)
        {
            if (ModelState.IsValid)
            {
                db.Inconformidades.Add(inconformidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inconformidade);
        }

        // GET: Inconformidade/Edit/5
        public ActionResult Edit(long? id)
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

        // POST: Inconformidade/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InconformidadeId,InconformidadeSeq,ListaSeq,MaterialCod,QtdeSeparada,DhInconformidade,FgEnviado")] Inconformidade inconformidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inconformidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inconformidade);
        }

        // GET: Inconformidade/Delete/5
        public ActionResult Delete(long? id)
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

        // POST: Inconformidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
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
