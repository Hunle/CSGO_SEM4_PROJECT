using DB.Arnes_Repo;
using CSGO_MVC.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Web.Security;

namespace CSGO_MVC.Controllers
{

    public class SteamAccCrudController : Controller
    {
        private IRepository<SteamAccount> AccountRepo = null;
        private BalanceController bctrl = new BalanceController();
        private SkinController sctrl = new SkinController();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(SteamAccount s)
        {
            if (ModelState.IsValid) // this is check validity
            {
                using (SteamAccountContext sc = new SteamAccountContext())
                {
                    var v = sc.Accounts.Where(a => a.UserName.Equals(s.UserName) && a.Password.Equals(s.Password)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LogedId"] = v.Id.ToString();
                        Session["LogedUserUserName"] = v.UserName.ToString();
                        return RedirectToAction("AfterLogin");
                    }
                }
            }
            return View(s);
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult AfterLogin()
        {
            if (Session["LogedId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public SteamAccCrudController()
        {
            this.AccountRepo = new Reposistory<SteamAccount>();
        }
        public ActionResult Index(SteamAccount steamacc)
        {
            SteamAccountContext scontext = new SteamAccountContext();
            
            return View();
        }

        public void GetAll()
        {
            var acc = AccountRepo.GetAll();            
        }

        [HttpGet]
        public ActionResult Create()
        {
            //Balance accBalance = bctrl.CreateonCreateAccount();

            //SteamAccount acc = new SteamAccount
            //{
            //    SteamId = Steamid,
            //    UserName = GetUsernameFromId(Steamid),
            //    Password = password,
            //    accountbalance = accBalance,
            //    TradeLink = Tradelink
                
            //};
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(SteamAccount acc)
        {
            acc.UserName = GetUsernameFromId(acc.SteamId);
            //acc.TradeLink = "templink";
            acc.UserStatus = false;
            if (ModelState.IsValid)
            {
                //Balance accountbalance = bctrl.CreateonCreateAccount();
                //acc.accountbalance = accountbalance;
                //acc.UserName = GetUsernameFromId(acc.SteamId);
                foreach (var item in acc.AccountSkins)
                {
                    sctrl.CreateonCreateAccount(item);
                }
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

        public string GetUsernameFromId(long Steamid)
        {
            // Ville være nemmere at ændre alle parameteren SteamId til string
            string steamid2 = Steamid.ToString();
            XDocument doc = XDocument.Load("http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v2/?key=8043B535FFFFA67E92D4542AD3EEDCDD&steamids=" + Uri.EscapeDataString(steamid2) + "&format=xml");


            //string UserName = (string)doc.Descendants("response").DescendantNodes("players").FirstOrDefault();

            string UserName = doc.Descendants("response").Single()
    .Descendants("players").Single().Descendants("player").Single().Descendants("personaname").Single().Value.ToString();


            return UserName;
        }
    }
}