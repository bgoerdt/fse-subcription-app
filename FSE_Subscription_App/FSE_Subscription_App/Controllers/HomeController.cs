using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FSE_Subscription_App.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			if (User.Identity.IsAuthenticated)
			{
				if (User.IsInRole("ContentManager"))
					ViewBag.Message = "WELCOME! Thanks for choosing MDG Productions for supplying your subscribers content. Create new subscriptions from the Subscriptions page below.";
				else
					ViewBag.Message = "WELCOME! Check out what our content providers have to offer through their custom-made subscriptions. View all of your subscriptions from your account page.";
			}
			else
				ViewBag.Message = "Check out a list of the content providers currently available to subscribe to below, then register an account to start subscribing to and viewing all your content in one location! If you are looking to be a content manager for a provider, please check the appropriate box on the register page and create an account for your company.";

			return View();
		}

		public ActionResult About()
		{
			return View();
		}

		public ActionResult Contact()
		{
			return View();
		}
	}
}
