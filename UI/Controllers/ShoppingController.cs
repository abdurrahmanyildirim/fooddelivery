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
    public class ShoppingController : Controller
    {

        private IOrderDetailDal _orderDetailDal;
        private IMenuDal _menuDal;
        private IUserDal _userDal;
        private IOrderDal _orderDal;
        private IAddressDal _addressDal;

        public ShoppingController()
        {
            _orderDetailDal = InstanceFactory.GetInstance<IOrderDetailDal>();
            _menuDal = InstanceFactory.GetInstance<IMenuDal>();
            _userDal = InstanceFactory.GetInstance<IUserDal>();
            _orderDal = InstanceFactory.GetInstance<IOrderDal>();
            _addressDal = InstanceFactory.GetInstance<IAddressDal>();
        }

        public ActionResult Cart()
        {
            if (Request.Cookies["user"] == null)
                return RedirectToAction("Error404", "Error");

            string cookie = Request.Cookies["user"].Value;
            return View(_addressDal.GetAddressByUserID(_userDal.GetUserByCookie(cookie).ID));
        }

        [HttpGet]
        public ActionResult Search(string menu)
        {
            return View(_menuDal.GetMenusByName(menu));
        }

        // Shopping/AddToCart
        public PartialViewResult AddToCart(int id)
        {
            string cookie = Request.Cookies["user"].Value;
            Menu menu = _menuDal.GetByID(id);
            User user = _userDal.GetUserByCookie(cookie);

            if (_orderDal.GetActiveOrderByUser(user.ID) == null)
            {
                Order order = new Order()
                {
                    AddressID = user.Addresses.FirstOrDefault(x => x.ID == x.User.ID).ID,
                    TotalPrice = menu.Price,
                    IsActive = true,
                    OrderDate = DateTime.Now,
                    BranchID = 1,//TODO:Dinamik hale getirilecek.
                    PaymentType = true,//TODO:Default olarak true değeri verilecek. Son satın alma esnasında set edilecek
                };
                _orderDal.Add(order);
            }
            else
            {
                Order order = _orderDal.GetActiveOrderByUser(user.ID);
                order.TotalPrice += menu.Price;
                order.OrderDate = DateTime.Now;
                _orderDal.Update(order);
            }

            int orderID = _orderDal.GetActiveOrderByUser(user.ID).ID;

            if (_orderDetailDal.GetCartByMenuUserOrder(menu.ID, user.ID, orderID) == null)
            {
                OrderDetail orderDetail = new OrderDetail()
                {
                    IsCompleted = false,
                    MenuID = menu.ID,
                    OrderID = orderID,
                    Quantity = 1, //TODO:Dinamik hale getirilebilir.
                    TotalAmount = menu.Price
                };
                _orderDetailDal.Add(orderDetail);
            }
            else
            {
                OrderDetail orderDetail = _orderDetailDal.GetCartByMenuUserOrder(menu.ID, user.ID, orderID);
                orderDetail.Quantity++;
                orderDetail.TotalAmount = orderDetail.Quantity * menu.Price;
                _orderDetailDal.Update(orderDetail);
            }
            

            return PartialView("~/Views/Login/_LoginCart.cshtml", _orderDetailDal.GetCartsByCookie(cookie));
        }


    }
}