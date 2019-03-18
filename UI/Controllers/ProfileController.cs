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
    public class ProfileController : Controller
    {
        IUserDal _userDal;
        IOrderDetailDal _orderDetailDal;
        IAddressDal _addressDal;
        IRegionDal _regionDal;
        public ProfileController()
        {
            _userDal = InstanceFactory.GetInstance<IUserDal>();
            _orderDetailDal = InstanceFactory.GetInstance<IOrderDetailDal>();
            _addressDal = InstanceFactory.GetInstance<IAddressDal>();
            _regionDal = InstanceFactory.GetInstance<IRegionDal>();
        }

        public ActionResult Order()
        {
            string cookie = Request.Cookies["user"].Value;
            User user = _userDal.GetUserByCookie(cookie);
            return View(_orderDetailDal.GetEntitiesByFilter(z => z.Order.Address.UserID == user.ID).ToList());
        }

        public ActionResult Address()
        {
            string cookie = Request.Cookies["user"].Value;
            User user = _userDal.GetUserByCookie(cookie);
            ViewBag.Ilceler = _regionDal.GetAll();
            return View(_addressDal.GetAddressByUserID(user.ID));
        }

        [HttpPost]
        public ActionResult Address(FormCollection frm)
        {
            string cookie = Request.Cookies["user"].Value;
            Address adres = new Address()
            {
                UserID = _userDal.GetUserByCookie(cookie).ID,
                Title = frm["baslik"],
                RegionID = Convert.ToInt32(frm["ilce"]),
                AddressDetail = frm["detay"]
            };
            _addressDal.Add(adres);
            return RedirectToAction("Address");
        }
    }
}