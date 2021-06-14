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
    public class ItemColetaMovimentacaosController : Controller
    {
        private ColetaContext db = new ColetaContext();

        // GET: ItemColetaMovimentacaos
        public ActionResult Index()
        {
            var itemColetaMovimentacaos = db.ItemColetaMovimentacaos.Include(i => i.ItemColeta);
            return View(itemColetaMovimentacaos.ToList());
        }

        // GET: ItemColetaMovimentacaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemColetaMovimentacao itemColetaMovimentacao = db.ItemColetaMovimentacaos.Find(id);
            if (itemColetaMovimentacao == null)
            {
                return HttpNotFound();
            }
            return View(itemColetaMovimentacao);
        }

        // GET: ItemColetaMovimentacaos/Create
        public ActionResult Create()
        {
            ViewBag.ItemColetaId = new SelectList(db.ItemColeta, "ItemColetaId", "Local_Coleta");
            return View();
        }

        // POST: ItemColetaMovimentacaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemColetaId,DescricaoMovimentacao,DhCriacao,NmUsuarioCriou")] ItemColetaMovimentacao itemColetaMovimentacao)
        {
            if (ModelState.IsValid)
            {
                db.ItemColetaMovimentacaos.Add(itemColetaMovimentacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemColetaId = new SelectList(db.ItemColeta, "ItemColetaId", "Local_Coleta", itemColetaMovimentacao.ItemColetaId);
            return View(itemColetaMovimentacao);
        }

        // GET: ItemColetaMovimentacaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemColetaMovimentacao itemColetaMovimentacao = db.ItemColetaMovimentacaos.Find(id);
            if (itemColetaMovimentacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemColetaId = new SelectList(db.ItemColeta, "ItemColetaId", "Local_Coleta", itemColetaMovimentacao.ItemColetaId);
            return View(itemColetaMovimentacao);
        }

        // POST: ItemColetaMovimentacaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemColetaId,DescricaoMovimentacao,DhCriacao,NmUsuarioCriou")] ItemColetaMovimentacao itemColetaMovimentacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemColetaMovimentacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemColetaId = new SelectList(db.ItemColeta, "ItemColetaId", "Local_Coleta", itemColetaMovimentacao.ItemColetaId);
            return View(itemColetaMovimentacao);
        }

        // GET: ItemColetaMovimentacaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemColetaMovimentacao itemColetaMovimentacao = db.ItemColetaMovimentacaos.Find(id);
            if (itemColetaMovimentacao == null)
            {
                return HttpNotFound();
            }
            return View(itemColetaMovimentacao);
        }

        // POST: ItemColetaMovimentacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemColetaMovimentacao itemColetaMovimentacao = db.ItemColetaMovimentacaos.Find(id);
            db.ItemColetaMovimentacaos.Remove(itemColetaMovimentacao);
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
