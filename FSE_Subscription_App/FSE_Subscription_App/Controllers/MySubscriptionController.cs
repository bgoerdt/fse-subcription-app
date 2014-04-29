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
   public class MySubscriptionController : Controller
    {
        private AppDbContext db = new AppDbContext();

        //
        // GET: /MySubscription/

        public ActionResult Index()
        {
            var userSubscriptions = db.UserProfiles.Find(WebSecurity.GetUserId(User.Identity.Name)).UserSubscriptions;
          
            return View(userSubscriptions.ToList());
        }

        ////
        //// GET: /MySubscription/Details/5

        //public ActionResult Details(int id = 0)
        //{
        //    UserProfile userprofile = db.UserProfiles.Find(id);
        //    if (userprofile == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(userprofile);
        //}

        ////
        //// GET: /MySubscription/Create

        //public ActionResult Create()
        //{
        //    return View();
        //}

        ////
        //// POST: /MySubscription/Create

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(UserProfile userprofile)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.UserProfiles.Add(userprofile);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(userprofile);
        //}

        ////
        //// GET: /MySubscription/Edit/5

        //public ActionResult Edit(int id = 0)
        //{
        //    UserProfile userprofile = db.UserProfiles.Find(id);
        //    if (userprofile == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(userprofile);
        //}

        ////
        //// POST: /MySubscription/Edit/5

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(UserProfile userprofile)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(userprofile).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(userprofile);
        //}

        ////
        //// GET: /MySubscription/Delete/5

        //public ActionResult Delete(int id = 0)
        //{
        //    UserProfile userprofile = db.UserProfiles.Find(id);
        //    if (userprofile == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(userprofile);
        //}

        ////
        //// POST: /MySubscription/Delete/5

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    UserProfile userprofile = db.UserProfiles.Find(id);
        //    db.UserProfiles.Remove(userprofile);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}