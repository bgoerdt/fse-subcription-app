using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FSE_Subscription_App.Models;
using System.Net; // added these two
using System.Net.Mail;

namespace FSE_Subscription_App.Controllers
{
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

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Provider/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Provider provider)
        {
            if (ModelState.IsValid)
            {
                db.Providers.Add(provider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }



            //start here 
            var fromAddress = new MailAddress("uiowafundofsoftwareeng@gmail.com", "From Name");
            var toAddress = new MailAddress("gunnar-mills@uiowa.edu", "To Name");
            string fromPassword = "kickbutt";
            string subject = "Subject";
            string body = "Body";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }


            //end here 




            return View(provider);
        }

        //
        // GET: /Provider/Edit/5

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