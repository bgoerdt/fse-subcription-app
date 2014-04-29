using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FSE_Subscription_App.Models;
using FSE_Subscription_App.Filters;
using WebMatrix.WebData;

namespace FSE_Subscription_App.Controllers
{
	[Authorize]
	[InitializeSimpleMembership]
    public class SearchController : Controller
    {
		SubHubSearch search = new SubHubSearch();
		AppDbContext db = new AppDbContext();
        //
        // GET: /Search/

        public ActionResult Search(string query)
        {
			if (User.IsInRole("ContentManager"))
			{
				ViewBag.ProviderID = db.UserProfiles.Find(WebSecurity.GetUserId(User.Identity.Name)).Provider.ID;
			}
			var user = db.UserProfiles.Find(WebSecurity.GetUserId(User.Identity.Name));
			ViewBag.UserSubscriptions = user.UserSubscriptions;
			search.query(db.Subscriptions.ToList(), db.Providers.ToList(), query);
            return View(search);
        }
    }
}
