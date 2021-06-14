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
    public class MestreColetasController : Controller
    {
        private ColetaContext db = new ColetaContext();

        // GET: MestreColetas
        public ActionResult Index()
        {
            return View(db.MestreCarga.ToList());
        }

        // GET: MestreColetas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MestreColeta mestreColeta = db.MestreCarga.Find(id);
            if (mestreColeta == null)
            {
                return HttpNotFound();
            }
            return View(mestreColeta);
        }

        // GET: MestreColetas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MestreColetas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MestreColetaId,CNH_Motorista,Previsao_Retorno")] MestreColeta mestreColeta)
        {
            if (ModelState.IsValid)
            {
                db.MestreCarga.Add(mestreColeta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mestreColeta);
        }

        // GET: MestreColetas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MestreColeta mestreColeta = db.MestreCarga.Find(id);
            if (mestreColeta == null)
            {
                return HttpNotFound();
            }
            return View(mestreColeta);
        }

        // POST: MestreColetas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MestreColetaId,CNH_Motorista,Previsao_Retorno")] MestreColeta mestreColeta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mestreColeta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mestreColeta);
        }

        // GET: MestreColetas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MestreColeta mestreColeta = db.MestreCarga.Find(id);
            if (mestreColeta == null)
            {
                return HttpNotFound();
            }
            return View(mestreColeta);
        }

        // POST: MestreColetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MestreColeta mestreColeta = db.MestreCarga.Find(id);
            db.MestreCarga.Remove(mestreColeta);
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
