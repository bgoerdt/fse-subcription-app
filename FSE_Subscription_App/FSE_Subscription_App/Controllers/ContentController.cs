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
    public class ContentController : Controller
    {
        private AppDbContext db = new AppDbContext();

        //
        // GET: /Content/

        public ActionResult Index()
        {
            var content = db.Content.Include(c => c.Provider);
            return View(content.ToList());
        }

        //
        // GET: /Content/Details/5

        public ActionResult Details(int id = 0)
        {
            Content content = db.Content.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

        //
        // GET: /Content/Create

        public ActionResult Create()
        {
            ViewBag.ProviderID = new SelectList(db.Providers, "ID", "CompanyName");
            return View();
        }

        //
        // POST: /Content/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Content content)
        {
            if (ModelState.IsValid)
            {
                db.Content.Add(content);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProviderID = new SelectList(db.Providers, "ID", "CompanyName", content.ProviderID);

        
            return View(content);
        }

        //
        // GET: /Content/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Content content = db.Content.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProviderID = new SelectList(db.Providers, "ID", "CompanyName", content.ProviderID);
            return View(content);
        }

        //
        // POST: /Content/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Content content)
        {
            if (ModelState.IsValid)
            {
                db.Entry(content).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProviderID = new SelectList(db.Providers, "ID", "CompanyName", content.ProviderID);
            return View(content);
        }

        //
        // GET: /Content/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Content content = db.Content.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

        //
        // POST: /Content/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Content content = db.Content.Find(id);
            db.Content.Remove(content);
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