using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CustomerPhoneNumber_2.Models;

namespace CustomerPhoneNumber_2.Controllers
{
    public class PhoneNumbersController : Controller
    {
        private CustomerDbContext db = new CustomerDbContext();

        // GET: PhoneNumbers
        public ActionResult Index()
        {
                 return View(db.phoneNumbers.ToList());
         }

        // GET: PhoneNumbers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneNumber phoneNumber = db.phoneNumbers.Find(id);
            if (phoneNumber == null)
            {
                return HttpNotFound();
            }
            return View(phoneNumber);
        }

        // GET: PhoneNumbers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhoneNumbers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,customerPhoneNumber,customerName,customerId,active")] PhoneNumber phoneNumber)
        {
            if (ModelState.IsValid)
            {
                db.phoneNumbers.Add(phoneNumber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phoneNumber);
        }

        // GET: PhoneNumbers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneNumber phoneNumber = db.phoneNumbers.Find(id);
            if (phoneNumber == null)
            {
                return HttpNotFound();
            }
            return View(phoneNumber);
        }

        // POST: PhoneNumbers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,customerPhoneNumber,customerName,customerId,active")] PhoneNumber phoneNumber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phoneNumber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phoneNumber);
        }

        // GET: PhoneNumbers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneNumber phoneNumber = db.phoneNumbers.Find(id);
            if (phoneNumber == null)
            {
                return HttpNotFound();
            }
            return View(phoneNumber);
        }

        // GET: PhoneNumbers/Delete/5
        public ActionResult CustomerPhoneNumbers()
        {
            //return View(db.phoneNumbers.Select(c => c.customerId).ToList());
            ViewBag.customerId = new SelectList(db.phoneNumbers, "Id", "customerId");
            //ViewBag.ManagerNames = new SelectList(db.Managers, "Id", "FirstName");
            return View();
        }


        // POST: PhoneNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhoneNumber phoneNumber = db.phoneNumbers.Find(id);
            db.phoneNumbers.Remove(phoneNumber);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost, ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult search(string customerId)
        {
            var phNumbers = new List<PhoneNumber>();
            if(customerId == string.Empty)
            {
                phNumbers = db.phoneNumbers.ToList();
            }
            else
            {
                phNumbers = db.phoneNumbers.Where(c => c.customerId == customerId).ToList();
            }
            return View(phNumbers);
        }
   }
}
