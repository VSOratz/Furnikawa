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
    public class SocialNetworkController : Controller
    {
        private ControleContext db = new ControleContext();

        // GET: SocialNetwork
        public ActionResult Index()
        {
            return View(db.SocialNetworks.ToList());
        }

        // GET: SocialNetwork/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialNetwork socialNetwork = db.SocialNetworks.Find(id);
            if (socialNetwork == null)
            {
                return HttpNotFound();
            }
            return View(socialNetwork);
        }

        // GET: SocialNetwork/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SocialNetwork/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SocialNetwork_ID,DescriptionSN,Nmparticipant,LinkSocial,APP_ID,REST_API_KEY,UserID,DhModification")] SocialNetwork socialNetwork)
        {
            socialNetwork.DhModification = DateTime.Now.ToShortDateString();
            if (ModelState.IsValid)
            {
                db.SocialNetworks.Add(socialNetwork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(socialNetwork);
        }

        // GET: SocialNetwork/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialNetwork socialNetwork = db.SocialNetworks.Find(id);
            if (socialNetwork == null)
            {
                return HttpNotFound();
            }
            return View(socialNetwork);
        }

        // POST: SocialNetwork/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SocialNetwork_ID,DescriptionSN,Nmparticipant,LinkSocial,APP_ID,REST_API_KEY,UserID,DhModification")] SocialNetwork socialNetwork)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socialNetwork).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(socialNetwork);
        }

        // GET: SocialNetwork/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialNetwork socialNetwork = db.SocialNetworks.Find(id);
            if (socialNetwork == null)
            {
                return HttpNotFound();
            }
            return View(socialNetwork);
        }

        // POST: SocialNetwork/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SocialNetwork socialNetwork = db.SocialNetworks.Find(id);
            db.SocialNetworks.Remove(socialNetwork);
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
