using CSGO_MVC.Models;
using DB.Arnes_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSGO_MVC.Controllers
{
    public class ViewModelController : Controller
    {
        private IRepository<Balance> BalRepo = null;
        // GET: ViewModel
        public ActionResult GetBalance()
        {
            _ViewModel vm = new _ViewModel();
            //vm.Balance = BalRepo.GetAll();

            return View(vm);
        }
    }
}