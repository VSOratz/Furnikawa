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
    public class ItemColetasController : Controller
    {
        private ColetaContext db = new ColetaContext();

        // GET: ItemColetas
        public ActionResult Index()
        {
            var itemColeta = db.ItemColeta.Include(i => i.MestreColeta);
            return View(itemColeta.ToList());
        }

        // GET: ItemColetas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemColeta itemColeta = db.ItemColeta.Find(id);
            if (itemColeta == null)
            {
                return HttpNotFound();
            }
            return View(itemColeta);
        }

        // GET: ItemColetas/Create
        public ActionResult Create()
        {
            ViewBag.MestreColetaId = new SelectList(db.MestreCarga, "MestreColetaId", "CNH_Motorista");
            return View();
        }

        // POST: ItemColetas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemColetaId,DhColeta,Local_Coleta,Valor,Quantidade,Peso,Nota,MestreColetaId")] ItemColeta itemColeta)
        {
            if (ModelState.IsValid)
            {
                db.ItemColeta.Add(itemColeta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MestreColetaId = new SelectList(db.MestreCarga, "MestreColetaId", "CNH_Motorista", itemColeta.MestreColetaId);
            return View(itemColeta);
        }

        // GET: ItemColetas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemColeta itemColeta = db.ItemColeta.Find(id);
            if (itemColeta == null)
            {
                return HttpNotFound();
            }
            ViewBag.MestreColetaId = new SelectList(db.MestreCarga, "MestreColetaId", "CNH_Motorista", itemColeta.MestreColetaId);
            return View(itemColeta);
        }

        // POST: ItemColetas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemColetaId,DhColeta,Local_Coleta,Valor,Quantidade,Peso,Nota,MestreColetaId")] ItemColeta itemColeta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemColeta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MestreColetaId = new SelectList(db.MestreCarga, "MestreColetaId", "CNH_Motorista", itemColeta.MestreColetaId);
            return View(itemColeta);
        }

        // GET: ItemColetas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemColeta itemColeta = db.ItemColeta.Find(id);
            if (itemColeta == null)
            {
                return HttpNotFound();
            }
            return View(itemColeta);
        }

        // POST: ItemColetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemColeta itemColeta = db.ItemColeta.Find(id);
            db.ItemColeta.Remove(itemColeta);
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
