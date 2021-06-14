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
    public class DocumentosController : Controller
    {
        private ColetaContext db = new ColetaContext();

        // GET: Documentos
        public ActionResult Index()
        {
            var documentos = db.Documentos.Include(d => d.ItemColeta);
            return View(documentos.ToList());
        }

        // GET: Documentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Documento documento = db.Documentos.Find(id);
            if (documento == null)
            {
                return HttpNotFound();
            }
            return View(documento);
        }

        // GET: Documentos/Create
        public ActionResult Create()
        {
            ViewBag.ItemColetaId = new SelectList(db.ItemColeta, "ItemColetaId", "Local_Coleta");
            return View();
        }

        // POST: Documentos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DocumentoId,DocumentoNum,DocumentoSeq,Photo,ItemColetaId")] Documento documento)
        {
            if (ModelState.IsValid)
            {
                db.Documentos.Add(documento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemColetaId = new SelectList(db.ItemColeta, "ItemColetaId", "Local_Coleta", documento.ItemColetaId);
            return View(documento);
        }

        // GET: Documentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Documento documento = db.Documentos.Find(id);
            if (documento == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemColetaId = new SelectList(db.ItemColeta, "ItemColetaId", "Local_Coleta", documento.ItemColetaId);
            return View(documento);
        }

        // POST: Documentos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DocumentoId,DocumentoNum,DocumentoSeq,Photo,ItemColetaId")] Documento documento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemColetaId = new SelectList(db.ItemColeta, "ItemColetaId", "Local_Coleta", documento.ItemColetaId);
            return View(documento);
        }

        // GET: Documentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Documento documento = db.Documentos.Find(id);
            if (documento == null)
            {
                return HttpNotFound();
            }
            return View(documento);
        }

        // POST: Documentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Documento documento = db.Documentos.Find(id);
            db.Documentos.Remove(documento);
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
