using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using DbLogic;
using Management;
using WMI;

namespace WebApiApp.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(DataManager dataManager)
        {
            _dataManager = dataManager;

            var _manager = new Manager(_dataManager, new WmInfo());
            _manager.Manage();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        private readonly DataManager _dataManager;
        private readonly Manager _manager;
    }
}
