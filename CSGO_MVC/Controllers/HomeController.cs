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
        private BetController bc = new BetController();
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

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Contact(Bet bet)           //Roulette
        {
            vm.ready = false;
            vm.Bets = bet;
            Field betfield = new Field();
            Field wfield = new Field();
            double amount = 0;


            foreach (var item in rc.Fieldlist)
            {
                vm.Fieldlist.Add(item);
            }

            int id = Convert.ToInt32(Session["LogedId"]);
            vm.Accounts = sc.GetById(id);

            if (vm.ready)
            {
               vm.Bets = BetOnGame(betfield, amount);
               wfield = getGame(vm.Bets);
               if( vm.Bets.Betfield.Color == wfield.Color && vm.Bets.Betfield.Number == wfield.Number)
                {
                    ViewBag.Message = "YOU WON! CONGRATULATIONS!";
                    vm.Accounts.accountbalance.Amount += vm.Bets.BetValue;
                }
                else
                {
                    ViewBag.Message = "YOU LOST! TOO BAD";
                    vm.Accounts.accountbalance.Amount -= vm.Bets.BetValue;
                }
                vm.ready = false;
            }
       
           return View(vm);
        }

        
        public Bet BetOnGame(Field field, double amount)
        {
            Bet bet = new Bet(amount);
            bet.Betfield = field;
            int id = Convert.ToInt32(Session["LogedId"]);
            bet.Betmaker = sc.GetById(id);
            bet.Date = DateTime.Now;
            bet.Status = false;
            bc.Create(bet);
            return bet;
            
        }

        
        public Field getGame(Bet bet)
        {
            Field wfield = new Field();
            wfield = rc.RouletteGame(bet);
            
            return wfield;

        }
    }
}