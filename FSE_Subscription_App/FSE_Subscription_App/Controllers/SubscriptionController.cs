using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FSE_Subscription_App.Models;

namespace FSE_Subscription_App.Controllers
{
    public class SubscriptionController : Controller
    {
        private AppDbContext db = new AppDbContext();

        //
        // GET: /Subscription/

        public ActionResult Index()
        {
            var subscriptions = db.Subscriptions.Include(s => s.Provider);
            return View(subscriptions.ToList());
        }

        //
        // GET: /Subscription/Details/5

        public ActionResult Details(int id = 0)
        {
            Subscription subscription = db.Subscriptions.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }

        //
        // GET: /Subscription/Create

        public ActionResult Create()
        {
            ViewBag.ProviderID = new SelectList(db.Providers, "ID", "CompanyName");
            return View();
        }

        //
        // POST: /Subscription/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Subscription subscription)
        {
            if (ModelState.IsValid)
            {
                db.Subscriptions.Add(subscription);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProviderID = new SelectList(db.Providers, "ID", "CompanyName", subscription.ProviderID);
            return View(subscription);
        }

        //
        // GET: /Subscription/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Subscription subscription = db.Subscriptions.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProviderID = new SelectList(db.Providers, "ID", "CompanyName", subscription.ProviderID);
            return View(subscription);
        }

        //
        // POST: /Subscription/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Subscription subscription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subscription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProviderID = new SelectList(db.Providers, "ID", "CompanyName", subscription.ProviderID);
            return View(subscription);
        }

        //
        // GET: /Subscription/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Subscription subscription = db.Subscriptions.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }

        //
        // POST: /Subscription/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subscription subscription = db.Subscriptions.Find(id);
            db.Subscriptions.Remove(subscription);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}