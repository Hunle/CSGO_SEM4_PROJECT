using DB.Arnes_Repo;
using CSGO_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


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
    }
}
