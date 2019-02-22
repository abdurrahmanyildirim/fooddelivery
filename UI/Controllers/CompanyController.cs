using FoodDelivery.DAL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class CompanyController : Controller
    {
        Context db;
        public CompanyController()
        {
            db = new Context();
        }
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult Branches()
        {

            return View(db.Branches.ToList());
        }
        public ActionResult Menus()
        {

            return View(db.Menus.ToList());
        }
        public ActionResult AddBranch()
        {
            ViewBag.Cities = db.Cities.ToList();
            ViewBag.Regions = db.Regions.ToList();
            return View();
        }
    }
}