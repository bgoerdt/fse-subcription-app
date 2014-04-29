using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using FSE_Subscription_App.Models;
using FSE_Subscription_App.Filters;

namespace FSE_Subscription_App.Controllers
{
	[Authorize]
	[InitializeSimpleMembership]
    public class SubscriptionController : Controller
    {
        private AppDbContext db = new AppDbContext();

        //
        // GET: /Subscription/

        public ActionResult Index()
        {
			if (User.IsInRole("ContentManager"))
			{
				ViewBag.ProviderID = db.UserProfiles.Find(WebSecurity.GetUserId(User.Identity.Name)).Provider.ID;
			}
			var user = db.UserProfiles.Find(WebSecurity.GetUserId(User.Identity.Name));
			ViewBag.UserSubscriptions = user.Subscriptions;
            var subscriptions = db.Subscriptions.Include(s => s.Provider);
			ViewBag.Warning = TempData["Warning"];
            return View(subscriptions.ToList());
        }

        //
        // GET: /Subscription/Details/5

        public ActionResult Details(int id = 0)
        {
            Subscription subscription = db.Subscriptions.Find(id);
			var user = db.UserProfiles.Find(WebSecurity.GetUserId(User.Identity.Name));
			if (!user.Subscriptions.Contains(subscription))
			{
				TempData.Add("Warning", "Please subscribe to see content");
				return RedirectToAction("Index");
			}
            if (subscription == null)
            {
                return HttpNotFound();
            }
			if (User.IsInRole("ContentManager"))
			{
				ViewBag.ProviderID = db.UserProfiles.Find(WebSecurity.GetUserId(User.Identity.Name)).Provider.ID;
			}
            return View(subscription);
        }

        //
        // GET: /Subscription/Create
		[Authorize(Roles = "ContentManager")]
        public ActionResult Create()
        {
			var user = db.UserProfiles.Find(WebSecurity.GetUserId(User.Identity.Name));
			ViewBag.Contents = new SelectList(db.Content.Where(c => c.ProviderID == user.Provider.ID), "ID", "Name");
			ViewBag.Provider = user.Provider.CompanyName;
            return View();
        }

		//
		// POST: /Subscription/Create

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "ContentManager")]
		public ActionResult Create(Subscription subscription, IEnumerable<int> contents)
		{
			if (ModelState.ContainsKey("Contents"))
				ModelState["Contents"].Errors.Clear();
			if (ModelState.IsValid)
			{
				if (contents == null)
					return View(subscription);

				foreach (var content_id in contents)
				{
					var content = db.Content.Find(content_id);
					subscription.Contents.Add(content);
					content.Subscriptions.Add(subscription);
				}
				var user = db.UserProfiles.Find(WebSecurity.GetUserId(User.Identity.Name));
				subscription.ProviderID = user.Provider.ID;
				subscription.Provider = user.Provider;
				db.Subscriptions.Add(subscription);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.Contents = new SelectList(db.Content, "ID", "Name");
			ViewBag.ProviderID = new SelectList(db.Providers, "ID", "CompanyName", subscription.ProviderID);
			return View(subscription);
		}

		// GET
		public ActionResult Subscribe(int id = 0)
		{
			Subscription subscription = db.Subscriptions.Find(id);
			if (subscription == null)
			{
				return HttpNotFound();
			}
			return View(subscription);
		}

		// POST
		[HttpPost]
		public ActionResult Subscribe(Subscription sub)
		{
			Subscription subscription = db.Subscriptions.Find(sub.ID);
			if (subscription != null)
			{
				var user = db.UserProfiles.Find(WebSecurity.GetUserId(User.Identity.Name));
				if (user == null)
				{
					return HttpNotFound();
				}

				user.Subscriptions.Add(subscription);
				db.SaveChanges();
				return RedirectToAction("Index", "MySubscription");
			}
			return View(subscription);
		}

		// GET
		public ActionResult Unsubscribe(int id = 0)
		{
			Subscription subscription = db.Subscriptions.Find(id);
			if (subscription == null)
			{
				return HttpNotFound();
			}
			return View(subscription);
		}

		// POST
		[HttpPost]
		public ActionResult Unsubscribe(Subscription sub)
		{
			Subscription subscription = db.Subscriptions.Find(sub.ID);
			if (subscription != null)
			{
				var user = db.UserProfiles.Find(WebSecurity.GetUserId(User.Identity.Name));
				if (user == null)
				{
					return HttpNotFound();
				}

				user.Subscriptions.Remove(subscription);
				db.SaveChanges();
				TempData.Add("Warning", "You have been unsubscribed");
                return RedirectToAction("Index", "MySubscription");
			}
			return View(subscription);
		}

        //
        // GET: /Subscription/Edit/5
		[Authorize(Roles = "ContentManager")]
        public ActionResult Edit(int id = 0)
        {
            Subscription subscription = db.Subscriptions.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
			var user = db.UserProfiles.Find(WebSecurity.GetUserId(User.Identity.Name));
			ViewBag.Provider = user.Provider.CompanyName;
            ViewBag.ProviderID = new SelectList(db.Providers, "ID", "CompanyName", subscription.ProviderID);
            return View(subscription);
        }

        //
        // POST: /Subscription/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "ContentManager")]
        public ActionResult Edit(Subscription subscription)
        {
            if (ModelState.IsValid)
            {
				var user = db.UserProfiles.Find(WebSecurity.GetUserId(User.Identity.Name));
				subscription.ProviderID = user.Provider.ID;
				subscription.Provider = user.Provider;
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
			foreach (Content content in subscription.Contents)
			{
				content.Subscriptions.Remove(subscription);
			}
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