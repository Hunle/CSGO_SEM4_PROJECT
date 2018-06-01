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
        private FieldController fc = new FieldController();
        _ViewModel vm = new _ViewModel();

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

           
           


            foreach (var item in rc.Fieldlist)
            {
                vm.Fieldlist.Add(item);
            }
            SelectList slist = new SelectList(vm.Fieldlist);
            ViewBag.DropDownList = slist;
            int id = Convert.ToInt32(Session["LogedId"]);
                    
            vm.Accounts = sc.GetById(id);

            return View(vm);

        }

        public Field getGame(Bet bet)
        {
            Field wfield = new Field();
            wfield = rc.RouletteGame(bet);
            return wfield;

        }
    }
}