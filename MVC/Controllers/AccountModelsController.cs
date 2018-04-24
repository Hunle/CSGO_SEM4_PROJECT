using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class AccountModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AccountModels
        public ActionResult Index()
        {
            return View(db.AccountModels.ToList());
        }

        // GET: AccountModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountModels accountModels = db.AccountModels.Find(id);
            if (accountModels == null)
            {
                return HttpNotFound();
            }
            return View(accountModels);
        }

        // GET: AccountModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ReleaseDate,Genre,Price")] AccountModels accountModels)
        {
            if (ModelState.IsValid)
            {
                db.AccountModels.Add(accountModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accountModels);
        }

        // GET: AccountModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountModels accountModels = db.AccountModels.Find(id);
            if (accountModels == null)
            {
                return HttpNotFound();
            }
            return View(accountModels);
        }

        // POST: AccountModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ReleaseDate,Genre,Price")] AccountModels accountModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accountModels);
        }

        // GET: AccountModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountModels accountModels = db.AccountModels.Find(id);
            if (accountModels == null)
            {
                return HttpNotFound();
            }
            return View(accountModels);
        }

        // POST: AccountModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccountModels accountModels = db.AccountModels.Find(id);
            db.AccountModels.Remove(accountModels);
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
    }
}
