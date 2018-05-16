using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CSGO_MVC.Models;
using DB.Arnes_Repo;

namespace CSGO_MVC.Controllers
{
    public class BalanceController : Controller
    {
        private IRepository<Balance> BalRepo = null;


        public BalanceController()
        {
            this.BalRepo = new Reposistory<Balance>();
        }
        public ActionResult Index()
        {
            var bal = BalRepo.GetAll();
            return View(bal);
        }

        public IEnumerable<Balance> GetAll()
        {
            var balances = BalRepo.GetAll();
            return balances;
        }

        [HttpGet]
        public Balance CreateonCreateAccount()
        {
            Balance balance = new Balance();
            BalRepo.Insert(balance);
            BalRepo.Save();
            return balance;
        }

        [HttpPost]
        public ActionResult Create(Balance balance)
        {
            if (ModelState.IsValid)
            {
                BalRepo.Insert(balance);
                BalRepo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(balance);
            }
        }


        public ActionResult Edit(int Id)
        {
            var balance = BalRepo.GetById(Id);
            return View(balance);
        }

        [HttpPost]
        public ActionResult Edit(Balance balance)
        {
            if (ModelState.IsValid)
            {
                BalRepo.Update(balance);
                BalRepo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(balance);
            }
        }

        public ActionResult Details(int Id)
        {
            var balance = BalRepo.GetById(Id);
            return View(balance);
        }
        public ActionResult Delete(int Id)
        {
            var balance = BalRepo.GetById(Id);
            return View(balance);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            var balance = BalRepo.GetById(Id);
            BalRepo.Delete(Id);
            BalRepo.Save();
            return RedirectToAction("Index");
        }
    }
}
