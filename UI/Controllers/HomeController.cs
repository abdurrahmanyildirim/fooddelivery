using FoodDelivery.DAL.Abstract;
using FoodDelivery.DAL.Concrete.Ninject;
using FoodDelivery.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        IContactDal _contactDal;

        public HomeController()
        {
            _contactDal = InstanceFactory.GetInstance<IContactDal>();
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactApply(FormCollection frm)
        {
            ContactForm contact = new ContactForm()
            {
                FullName = frm["fullName"],
                Email = frm["email"],
                Message = frm["message"]
            };
            _contactDal.Add(contact);

            return RedirectToAction("Index","Home");
        }
    }
}