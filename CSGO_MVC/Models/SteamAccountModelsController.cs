using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DB;
using Models;

namespace CSGO_MVC.Models
{
    public class SteamAccountModelsController : Controller
    {
        private DataAccess db = new DataAccess();
        private AccountRepository Accrep = new AccountRepository();

        // GET: SteamAccountModels
        public ActionResult Index()
        {
            return View(Accrep.LoadAll());
        }

        // GET: SteamAccountModels/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account steamAccountModels = Accrep.Load(id);
            if (steamAccountModels == null)
            {
                return HttpNotFound();
            }
            return View(steamAccountModels);
        }

        // GET: SteamAccountModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SteamAccountModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SteamId,Name,Status,TradeLink")] Account steamAccountModels)
        {

            try { 
            if (ModelState.IsValid)
            {
                Accrep.Save(steamAccountModels);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(steamAccountModels);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        // GET: SteamAccountModels/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account steamAccountModels = Accrep.Load(id);
            if (steamAccountModels == null)
            {
                return HttpNotFound();
            }
            return View(steamAccountModels);
        }

        // POST: SteamAccountModels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SteamId,Name,Status,TradeLink")] Account steamAccountModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(steamAccountModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(steamAccountModels);
        }

        // GET: SteamAccountModels/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account steamAccountModels = Accrep.Load(id);
            if (steamAccountModels == null)
            {
                return HttpNotFound();
            }
            return View(steamAccountModels);
        }

        // POST: SteamAccountModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account steamAccountModels = Accrep.Load(id);
            Accrep.Delete(steamAccountModels.Id);
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
