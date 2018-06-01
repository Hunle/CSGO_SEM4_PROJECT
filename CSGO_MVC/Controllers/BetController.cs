using DB.Arnes_Repo;
using CSGO_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CSGO_MVC.Controllers
{
    public class BetController : Controller
    {
        private IRepository<Bet> BetRepo = null;
        private SteamAccCrudController stctrl = new SteamAccCrudController();


        public BetController()
        {
            this.BetRepo = new Reposistory<Bet>();
        }
        public ActionResult Index()
        {
            var bet = BetRepo.GetAll();
            return View(bet);
        }

        public void GetAll()
        {
            var bet = BetRepo.GetAll();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Bet bet)
        {
            if (ModelState.IsValid)
            {
               // bet.Betmaker = stctrl.GetById(?)
                bet.Date = DateTime.Now;
                BetRepo.Insert(bet);
                BetRepo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(bet);
            }
        }


        public ActionResult Edit(int Id)
        {
            var bet = BetRepo.GetById(Id);
            return View(bet);
        }

        [HttpPost]
        public ActionResult Edit(Bet bet)
        {
            if (ModelState.IsValid)
            {
                BetRepo.Update(bet);
                BetRepo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(bet);
            }
        }

        public ActionResult Details(int Id)
        {
            var bet = BetRepo.GetById(Id);
            ViewBag.BetVal = BetRepo.GetById(Id);
            return View(bet);
        }
        public ActionResult Delete(int Id)
        {
            var bet = BetRepo.GetById(Id);
            return View(bet);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            var bet = BetRepo.GetById(Id);
            BetRepo.Delete(Id);
            BetRepo.Save();
            return RedirectToAction("Index");
        }
    }
}