using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FSE_Subscription_App.Models;
using WebMatrix.WebData;
using FSE_Subscription_App.Filters;


namespace FSE_Subscription_App.Controllers
{
	[InitializeSimpleMembership]
    public class ProviderController : Controller
    {
        private AppDbContext db = new AppDbContext();

        //
        // GET: /Provider/

        public ActionResult Index()
        {
            return View(db.Providers.ToList());
        }

        //
        // GET: /Provider/Details/5
		[Authorize]
        public ActionResult Details(int id = 0)
        {
            Provider provider = db.Providers.Find(id);
            if (provider == null)
            {
                return HttpNotFound();
            }
            return View(provider);
        }

        //
        // GET: /Provider/Create
		[Authorize(Roles = "ContentManager")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Provider/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "ContentManager")]
        public ActionResult Create(Provider provider)
        {
            if (ModelState.IsValid)
            {
                db.Providers.Add(provider);
				var user = db.UserProfiles.Find(WebSecurity.GetUserId(User.Identity.Name));
				user.Provider = provider;
                db.SaveChanges();
                return RedirectToAction("Details", provider);
            }

            return View(provider);
        }

        //
        // GET: /Provider/Edit/5
		[Authorize(Roles = "ContentManager")]
        public ActionResult Edit(int id = 0)
        {
            Provider provider = db.Providers.Find(id);
            if (provider == null)
            {
                return HttpNotFound();
            }
            return View(provider);
        }

        //
        // POST: /Provider/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "ContentManager")]
        public ActionResult Edit(Provider provider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(provider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(provider);
        }

        //
        // GET: /Provider/Delete/5
		[Authorize(Roles = "ContentManager")]
        public ActionResult Delete(int id = 0)
        {
            Provider provider = db.Providers.Find(id);
            if (provider == null)
            {
                return HttpNotFound();
            }
            return View(provider);
        }

        //
        // POST: /Provider/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "ContentManager")]
        public ActionResult DeleteConfirmed(int id)
        {
            Provider provider = db.Providers.Find(id);
            db.Providers.Remove(provider);
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