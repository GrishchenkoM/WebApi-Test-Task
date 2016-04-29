using System;
using System.Web.Mvc;
using DbLogic;
using Domain;
using Management;
using WebApiApp.Models;
using WMI;

namespace WebApiApp.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(DataManager dataManager)
        {
            _dataManager = dataManager;

            _manager = new Manager(_dataManager, new WmInfo());

            Common.DataManager = _dataManager;
            Common.Manager = _manager;
        }
        public ActionResult Index()
        {
            EntitiesModel model;
            try
            {
                model = new ViewModel(_dataManager).Model;

                if(model == null)
                    throw new Exception("Не удалось прочесть информацию из базы данных");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
            return View(model);
        }

        private readonly DataManager _dataManager;
        private readonly Manager _manager;
    }
}
