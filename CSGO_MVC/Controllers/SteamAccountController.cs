using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DB;
using Models;



namespace CSGO_MVC.Controllers
{
    public class SteamAccountController : Controller
    {

        AccountRepository AccRep = new AccountRepository();
        public ActionResult LoadSteamAccount()
        {

            
            return View();

        }

        // GET: SteamAccount
        public String Index()
        {
            return "Test Works";
        }
        public ActionResult SteamAccount()
        {
            Account acc = AccRep.Load(1);
            return View();
        }
    }
}
