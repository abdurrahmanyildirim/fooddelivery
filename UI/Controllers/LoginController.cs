﻿using FoodDelivery.DAL.Abstract;
using FoodDelivery.DAL.Concrete.Ninject;
using FoodDelivery.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class LoginController : Controller
    {
        IUserDal _userDal;
        IOrderDetailDal _orderDetailDal;

        public LoginController()
        {
            _userDal = InstanceFactory.GetInstance<IUserDal>();
            _orderDetailDal = InstanceFactory.GetInstance<IOrderDetailDal>();
        }

        public PartialViewResult _UserLoginPanel()
        {
            if (HttpContext.Request.Cookies["user"] != null)
            {
                string cookie = Request.Cookies["user"].Value;
                return PartialView("~/Views/Login/_UserLoginPanel.cshtml", _userDal.GetUserByCookie(cookie));
            }
            else
            {
                return PartialView();
            }
        }

        public PartialViewResult _SepetSection()
        {
            string cookie = Request.Cookies["user"].Value;
            return PartialView("~/Views/Login/_LoginCart.cshtml", _orderDetailDal.GetCartsByCookie(cookie));
        }

    }
}