using DB.Arnes_Repo;
using CSGO_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;


namespace CSGO_MVC.Controllers
{
    public class SkinController : Controller
    {
        private IRepository<Skin> SkinRepo = null;


        public SkinController()
        {
            this.SkinRepo = new Reposistory<Skin>();
        }
        public ActionResult Index()
        {
            var skins = SkinRepo.GetAll();
            return View(skins);
        }

        public void GetAll()
        {
            var skins = SkinRepo.GetAll();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Skin skin)
        {
            if (ModelState.IsValid)
            {
                // bet.Betmaker = stctrl.GetById(?)               
                SkinRepo.Insert(skin);
                SkinRepo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(skin);
            }
        }
        public void CreateonCreateAccount(Skin skin)
        {
       
            SkinRepo.Insert(skin);
            SkinRepo.Save();
            
        }


        public ActionResult Edit(int Id)
        {
            var skin = SkinRepo.GetById(Id);
            return View(skin);
        }

        [HttpPost]
        public ActionResult Edit(Skin skin)
        {
            if (ModelState.IsValid)
            {
                SkinRepo.Update(skin);
                SkinRepo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(skin);
            }
        }

        public ActionResult Details(int Id)
        {
            var skin = SkinRepo.GetById(Id);
            return View(skin);
        }
        public ActionResult Delete(int Id)
        {
            var skin = SkinRepo.GetById(Id);
            return View(skin);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            var skin = SkinRepo.GetById(Id);
            SkinRepo.Delete(Id);
            SkinRepo.Save();
            return RedirectToAction("Index");
        }

        public IEnumerable<Skin> GetAccountSkins(long Steamid)
        {
            // ville igen være nemmere bare at gøre parameteren til string
            string steamid2 = Steamid.ToString();
            // ** WebApiErrorMessage": "Method permanently disabled, see https://developer.valvesoftware.com/wiki/Counter-Strike:_Global_Offensive_Economy_Items" TAK VALVE
            XDocument doc = XDocument.Load("http://api.steampowered.com/IEconItems_730/GetPlayerItems/v1/?key=8043B535FFFFA67E92D4542AD3EEDCDD&steamid=" + Uri.EscapeDataString(steamid2) + " & format=xml");
            List<Skin> skinlist = doc.Descendants("Counter-Strike:GlobalOffensive_EcoItems").Select(d =>
                        new Skin
                            {
                                Name = (string) d.Attribute("SkinName"),
                                Price = (int) d.Attribute("MarketPrice"),
                                State = (string) d.Attribute("Quality")
                            }).ToList();
            return skinlist;
        }
    }
}
