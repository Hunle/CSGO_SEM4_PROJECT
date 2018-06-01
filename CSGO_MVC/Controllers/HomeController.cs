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
        private IRepository<Balance> BalRepo = new Reposistory<Balance>();
        private SteamAccCrudController sc = new SteamAccCrudController();
        private RouletteController rc = new RouletteController();

        public ActionResult Index()     // Home 
        {
            return View();
        }

        public ActionResult About()             // Shop 
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()           //Roulette
        {

           
            _ViewModel vm = new _ViewModel();


            foreach (var item in rc.Fieldlist)
            {
                vm.Fieldlist.Add(item);
            }

            int id = Convert.ToInt32(Session["LogedId"]);

            vm.Accounts = sc.GetById(id);

            return View(vm);

        }
    }
}