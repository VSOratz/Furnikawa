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
    public class NotificationSocialNetworksController : Controller
    {
        private ControleContext db = new ControleContext();

        // GET: NotificationSocialNetworks
        public ActionResult Index()
        {
            return View(db.NotificationSocialNetworks.ToList());
        }

        // GET: NotificationSocialNetworks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotificationSocialNetwork notificationSocialNetwork = db.NotificationSocialNetworks.Find(id);
            if (notificationSocialNetwork == null)
            {
                return HttpNotFound();
            }
            return View(notificationSocialNetwork);
        }

        // GET: NotificationSocialNetworks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NotificationSocialNetworks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NotificationSocialNetwork_ID,DescriptionSN,Nmparticipant,LinkSocial,UserID,DhModification")] NotificationSocialNetwork notificationSocialNetwork)
        {
            if (ModelState.IsValid)
            {
                db.NotificationSocialNetworks.Add(notificationSocialNetwork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(notificationSocialNetwork);
        }

        // GET: NotificationSocialNetworks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotificationSocialNetwork notificationSocialNetwork = db.NotificationSocialNetworks.Find(id);
            if (notificationSocialNetwork == null)
            {
                return HttpNotFound();
            }
            return View(notificationSocialNetwork);
        }

        // POST: NotificationSocialNetworks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NotificationSocialNetwork_ID,DescriptionSN,Nmparticipant,LinkSocial,UserID,DhModification")] NotificationSocialNetwork notificationSocialNetwork)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notificationSocialNetwork).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notificationSocialNetwork);
        }

        // GET: NotificationSocialNetworks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotificationSocialNetwork notificationSocialNetwork = db.NotificationSocialNetworks.Find(id);
            if (notificationSocialNetwork == null)
            {
                return HttpNotFound();
            }
            return View(notificationSocialNetwork);
        }

        // POST: NotificationSocialNetworks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NotificationSocialNetwork notificationSocialNetwork = db.NotificationSocialNetworks.Find(id);
            db.NotificationSocialNetworks.Remove(notificationSocialNetwork);
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
