using DB;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSGO_MVC.Controllers
{
    public class SteamAccController : Controller
    {
        AccountRepository accrep = null;

        public SteamAccController()
        {
            this.accrep = new AccountRepository(); 
        }
        public ActionResult Index()
        {
            var account = accrep.Load(1);
            return View(account);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Account account)
        {
            if (ModelState.IsValid)
            {
                accrep.Save(account);
                
                return RedirectToAction("Index");
            }
            else
            {
                return View(account);
            }
        }


        public ActionResult Edit(int Id)
        {
            var account = accrep.Load(Id);
            return View(account);
        }

        [HttpPost]
        public ActionResult Edit(Account account)
        {
            if (ModelState.IsValid)
            {
                accrep.Save(account);
                return RedirectToAction("Index");
            }
            else
            {
                return View(account);
            }
        }

        public ActionResult Details(int Id)
        {
            var account = accrep.Load(Id);
            return View(account);
        }
        public ActionResult Delete(int Id)
        {
            var account = accrep.Load(Id);
            return View(account);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            var acc = accrep.Load(Id);
            accrep.Delete(Id);

            return RedirectToAction("Index");
        }
    }
}