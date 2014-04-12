using System.Web;
using System.Web.Optimization;

namespace FSE_Subscription_App
{
	public class BundleConfig
	{
		// For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
						"~/Scripts/jquery-ui-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.unobtrusive*",
						"~/Scripts/jquery.validate*"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new StyleBundle("~/App_Content/css").Include("~/App_Content/site.css"));

			bundles.Add(new StyleBundle("~/App_Content/themes/base/css").Include(
						"~/App_Content/themes/base/jquery.ui.core.css",
						"~/App_Content/themes/base/jquery.ui.resizable.css",
						"~/App_Content/themes/base/jquery.ui.selectable.css",
						"~/App_Content/themes/base/jquery.ui.accordion.css",
						"~/App_Content/themes/base/jquery.ui.autocomplete.css",
						"~/App_Content/themes/base/jquery.ui.button.css",
						"~/App_Content/themes/base/jquery.ui.dialog.css",
						"~/App_Content/themes/base/jquery.ui.slider.css",
						"~/App_Content/themes/base/jquery.ui.tabs.css",
						"~/App_Content/themes/base/jquery.ui.datepicker.css",
						"~/App_Content/themes/base/jquery.ui.progressbar.css",
						"~/App_Content/themes/base/jquery.ui.theme.css"));
		}
	}
}