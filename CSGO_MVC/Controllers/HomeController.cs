using CSGO_MVC.Models;
using DB.Arnes_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSGO_MVC.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Balance> BalRepo = null;

        public ActionResult Index()     // Home 
        {
            return View();
        }

        public ActionResult About()             // Shop 
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(int id)           //Roulette
        {
            ViewBag.Message = "Your contact page.";

            
                ViewBag.Wallet = BalRepo.GetById(id);

                return View();
 
          
        }
    }
}