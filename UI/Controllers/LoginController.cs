using FoodDelivery.DAL.Abstract;
using FoodDelivery.DAL.Concrete.Ninject;
using FoodDelivery.Entities;
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

        public LoginController()
        {
            _userDal = InstanceFactory.GetInstance<IUserDal>();

        }

        [HttpPost]
        public ActionResult Login(FormCollection frm)
        {
            string userName = frm["email"];
            string password = frm["password"];
            if (_userDal.GetUserByLogin(userName, password) != null)
            {
                User myUser = _userDal.GetUserByLogin(userName, password);
                string cerezKodu = Guid.NewGuid().ToString("n").Substring(0, 12);
                HttpCookie myCookie = new HttpCookie("user", cerezKodu);
                myCookie.Expires = DateTime.Now.AddDays(5);
                Response.Cookies.Add(myCookie);
                myUser.Cookie = cerezKodu;
                _userDal.Update(myUser);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("About", "Home");
            }
        }
    }
}