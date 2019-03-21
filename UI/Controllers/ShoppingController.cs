using FoodDelivery.DAL.Abstract;
using FoodDelivery.DAL.Concrete.Ninject;
using FoodDelivery.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.DTOs;

namespace UI.Controllers
{
    public class ShoppingController : Controller
    {

        private IOrderDetailDal _orderDetailDal;
        private IMenuDal _menuDal;
        private IUserDal _userDal;
        private IOrderDal _orderDal;
        private IAddressDal _addressDal;
        private IReviewDal _reviewDal;

        public ShoppingController()
        {
            _orderDetailDal = InstanceFactory.GetInstance<IOrderDetailDal>();
            _menuDal = InstanceFactory.GetInstance<IMenuDal>();
            _userDal = InstanceFactory.GetInstance<IUserDal>();
            _orderDal = InstanceFactory.GetInstance<IOrderDal>();
            _addressDal = InstanceFactory.GetInstance<IAddressDal>();
            _reviewDal = InstanceFactory.GetInstance<IReviewDal>();
        }

        public ActionResult Cart()
        {
            string cookie = "";
            
            if(Request.Cookies["user"] != null)
            {
                cookie = Request.Cookies["user"].Value;
            }
            return View(_addressDal.GetAddressByUserID(_userDal.GetUserByCookie(cookie).ID));
        }

        [HttpGet]
        public ActionResult Search(string menu)
        {
            ICollection<MenuPointDto> menum = PuanliMenuler(_menuDal.GetMenusByNameOrCompany(menu));
            return View(menum);
        }

        private List<MenuPointDto> PuanliMenuler(ICollection<Menu> menu)
        {
            List<MenuPointDto> menus = new List<MenuPointDto>();
            foreach (Menu item in menu)
            {
                int puan = 0;
                ICollection<Review> reviews = _reviewDal.GetReviewsByMenu(item.ID);
                if(reviews.Count() > 0)
                {
                    foreach (Review review in reviews)
                    {
                        puan += review.Point;
                    }
                    puan = puan / reviews.Count();
                }

                MenuPointDto midto = new MenuPointDto()
                {
                    Menu = item,
                    Point = puan
                };
                menus.Add(midto);
            }
            return menus;
        }

    }
}