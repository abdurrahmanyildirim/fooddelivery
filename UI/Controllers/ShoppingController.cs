using FoodDelivery.DAL.Abstract;
using FoodDelivery.DAL.Concrete.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class ShoppingController : Controller
    {

        IOrderDetailDal _orderDetailDal;

        public ShoppingController()
        {
            _orderDetailDal = InstanceFactory.GetInstance<IOrderDetailDal>();
        }
       
        public ActionResult Cart()
        {
            if (Request.Cookies["user"] == null)
                return RedirectToAction("Error404", "Error");

            string cookie = Request.Cookies["user"].Value;

            return View(_orderDetailDal.GetCartByCookie(cookie));
        }
    }
}