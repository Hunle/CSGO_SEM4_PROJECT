using DB.Arnes_Repo;
using CSGO_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSGO_MVC.Controllers
{
    public class SteamAccCrudController : Controller
    {
        private IRepository<SteamAccount> AccountRepo = null;
        private BalanceController bctrl = new BalanceController();


        public SteamAccCrudController()
        {
            this.AccountRepo = new Reposistory<SteamAccount>();
        }
        public ActionResult Index()
        {
            var acc = AccountRepo.GetAll();
            return View(acc);
        }

        public void GetAll()
        {
            var acc = AccountRepo.GetAll();            
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SteamAccount acc)
        {
            if (ModelState.IsValid)
            {
                Balance accountbalance = bctrl.CreateonCreateAccount();
                acc.accountbalance = accountbalance;
                AccountRepo.Insert(acc);
                AccountRepo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(acc);
            }
        }


        public ActionResult Edit(int Id)
        {
            var acc = AccountRepo.GetById(Id);
            return View(acc);
        }

        [HttpPost]
        public ActionResult Edit(SteamAccount acc)
        {
            if (ModelState.IsValid)
            {
                AccountRepo.Update(acc);
                AccountRepo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(acc);
            }
        }

        public SteamAccount GetById(int Id)
        {
            var acc = AccountRepo.GetById(Id);
            return acc;
        }
        public ActionResult Details(int Id)
        {
            var acc = AccountRepo.GetById(Id);
            return View(acc);
        }
        public ActionResult Delete(int Id)
        {
            var acc = AccountRepo.GetById(Id);
            return View(acc);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            var acc = AccountRepo.GetById(Id);
            AccountRepo.Delete(Id);
            AccountRepo.Save();
            return RedirectToAction("Index");
        }
    }
}