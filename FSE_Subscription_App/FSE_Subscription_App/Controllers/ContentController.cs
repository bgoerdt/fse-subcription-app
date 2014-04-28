using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FSE_Subscription_App.Models;
using System.IO;

namespace FSE_Subscription_App.Controllers
{
	[Authorize]
    public class ContentController : Controller
    {
        private AppDbContext db = new AppDbContext();

        //
        // GET: /Content/
        public ActionResult Index()
        {
			/*Content videoTest = new Content();
			videoTest.ContentType = "video/wmv";
			videoTest.Description = "video test";
			videoTest.Name = "video test - wmv";
			videoTest.ProviderID = 1;
			videoTest.ServerPath = "\\Uploaded_Content\\MyCompany\\Wildlife.wmv";
			db.Content.Add(videoTest);
			db.SaveChanges();*/

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

		public ActionResult Video(int id = 0)
		{
			Content content = db.Content.Find(id);
			if (content == null)
			{
				return null;
			}

			ViewBag.path = content.ServerPath;
			return View(content);
		}

		public ActionResult Audio(int id = 0)
		{
			Content content = db.Content.Find(id);
			if (content == null)
			{
				return null;
			}

			ViewBag.path = content.ServerPath;
			return View(content);
		}

		public FilePathResult ViewContent(int id = 0)
		{
			Content content = db.Content.Find(id);
			if (content == null)
			{
				return null;
			}

			return new FilePathResult(content.ServerPath, content.ContentType);
		}

        //
        // GET: /Content/Create
		[Authorize(Roles = "ContentManager")]
        public ActionResult Create()
        {
            ViewBag.ProviderID = new SelectList(db.Providers, "ID", "CompanyName");
            return View();
        }

		//
		// POST: /Content/Create

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "ContentManager")]
		public ActionResult Create(Content content, HttpPostedFileBase file)
		{
			if (ModelState.IsValid)
			{
				string companyName = db.Providers.Find(content.ProviderID).CompanyName;
				string path = HttpContext.Server.MapPath("~/Uploaded_Content/" + companyName + "/");

				if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
				{
					if (!Directory.Exists(path))
					{
						Directory.CreateDirectory(path);
					}

					char[] separators = { '\\' }; 
					string[] split = file.FileName.Split(separators, StringSplitOptions.RemoveEmptyEntries);
					string fileName = split[split.Length-1];
					file.SaveAs(path + fileName);
					content.ServerPath = "/Uploaded_Content/" + companyName + "/" + fileName;
					content.ContentType = file.ContentType;
				}

				db.Content.Add(content);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.ProviderID = new SelectList(db.Providers, "ID", "CompanyName", content.ProviderID);
			return View(content);
		}

        //
        // GET: /Content/Edit/5
		[Authorize(Roles = "ContentManager")]
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
		[Authorize(Roles = "ContentManager")]
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
			string filePath = content.ServerPath;
			if(System.IO.File.Exists(filePath))
				System.IO.File.Delete(filePath);
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