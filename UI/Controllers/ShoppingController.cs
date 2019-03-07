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

        private IOrderDetailDal _orderDetailDal;
        private IMenuDal _menuDal;

        public ShoppingController()
        {
            _orderDetailDal = InstanceFactory.GetInstance<IOrderDetailDal>();
            _menuDal = InstanceFactory.GetInstance<IMenuDal>();
        }
       
        public ActionResult Cart()
        {
            if (Request.Cookies["user"] == null)
                return RedirectToAction("Error404", "Error");

            string cookie = Request.Cookies["user"].Value;

            return View(_orderDetailDal.GetCartByCookie(cookie));
        }

        [HttpPost]
        public ActionResult Search(FormCollection frm)
        {
            string menu = frm["menu"];
            return View(_menuDal.GetMenusByName(menu));
        }
    }
}