using FoodDelivery.DAL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
           
            
            Context db = new Context();
            

            return View(db.CompanyApplies.ToList());
        }

        public ActionResult Add()
        {
            return View();
        }

    }
}