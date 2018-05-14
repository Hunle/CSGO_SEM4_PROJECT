using DB.Arnes_Repo;
using CSGO_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSGO_MVC.Controllers
{
    public class FieldController : Controller
    {
        private IRepository<Field> FieldRepo = null;


        public FieldController()
        {
            this.FieldRepo = new Reposistory<Field>();
        }
        public ActionResult Index()
        {
            var acc = FieldRepo.GetAll();
            return View(acc);
        }

        public IEnumerable<Field> GetAll()
        {
            var fields = FieldRepo.GetAll();
            return fields;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Field field)
        {
            if (ModelState.IsValid)
            {
                FieldRepo.Insert(field);
                FieldRepo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(field);
            }
        }


        public ActionResult Edit(int Id)
        {
            var field = FieldRepo.GetById(Id);
            return View(field);
        }

        [HttpPost]
        public ActionResult Edit(Field field)
        {
            if (ModelState.IsValid)
            {
                FieldRepo.Update(field);
                FieldRepo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(field);
            }
        }

        public ActionResult Details(int Id)
        {
            var field = FieldRepo.GetById(Id);
            return View(field);
        }
        public ActionResult Delete(int Id)
        {
            var field = FieldRepo.GetById(Id);
            return View(field);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            var field = FieldRepo.GetById(Id);
            FieldRepo.Delete(Id);
            FieldRepo.Save();
            return RedirectToAction("Index");
        }
    }
}