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
        public _ViewModel vm = new _ViewModel();
     

        

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

            vm.Fieldlists = new List<Field>();
            foreach (var item in rc.Fieldlist)
            {
                vm.Fieldlists.Add(item);
            }
            int id = Convert.ToInt32(Session["LogedId"]);
            vm.Accounts = sc.GetById(id);
            return View(vm);
        }



        [HttpPost]
        public ActionResult Contact(_ViewModel vm2)           //Roulette
        {

            //vm.Fieldlist = new List<Field>();
            //foreach (var item in rc.Fieldlist)
            //{
            //    vm.Fieldlist.Add(item);
            //}
            vm.Bets = vm2.Bets;
            Field betfield = new Field();
            //betfield.Color = color;
            //betfield.Number = Convert.ToInt32(number);
            vm.Bets.Betfield = betfield;
            //foreach (var item in rc.Fieldlist)
            //{
            //    vm.Fieldlists.Add(item);
            //}                       
            Field wfield = new Field();
            double amount = 0;
            int id = Convert.ToInt32(Session["LogedId"]);
            vm.Accounts = sc.GetById(id);

            if (vm.Bets.Betfield != null && vm.Bets.BetValue != 0)
            {
                vm.ready = true;
            }        

            if (vm.ready)
            {
               vm.Bets = BetOnGame(betfield, amount);
               wfield = getGame(vm.Bets);
               if( vm.Bets.Betfield.Color == wfield.Color && vm.Bets.Betfield.Number == wfield.Number)
                {
                    ViewBag.Message = "YOU WON! CONGRATULATIONS!";
                    
                }
                else
                {
                    ViewBag.Message = "YOU LOST! TOO BAD";
                   
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
            //bc.Create(bet);
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