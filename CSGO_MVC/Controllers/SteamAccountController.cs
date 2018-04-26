using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DB;
using Models;
using System.Net;



namespace CSGO_MVC.Controllers
{
    public class SteamAccountController : Controller
    {

        AccountRepository AccRep = new AccountRepository();
        public ActionResult LoadSteamAccount()
        {

            Account acc = AccRep.Load(1);
            return View();

        }

        // GET: SteamAccount
        public ActionResult Index()
        {
            Account acc = AccRep.Load(1);
            return View(acc);
        }
        public ActionResult SteamAccount()
        {
            Account acc = AccRep.Load(1);

            return View(); 
           

        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = AccRep.Load(1);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }
    }
}
