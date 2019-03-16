using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FoodDelivery.DAL.Abstract;
using FoodDelivery.DAL.Concrete.Ninject;
using FoodDelivery.Entities.Concrete;
using System.Web;
using UI.DTOs;

namespace UI.Controllers
{
    public class ServiceController : ApiController
    {
        IUserDal _userDal;
        public ServiceController()
        {
            _userDal = InstanceFactory.GetInstance<IUserDal>();
        }

        //Adres:  api/Service/Login
        [HttpPost]
        public HttpResponseMessage Login(UserLoginDto login)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Hatalı işlem yaptınız!");

            string userName = login.Email;
            string password = login.Password;
            User myUser = _userDal.GetUserByLogin(userName, password);
            if (myUser != null)
            {
                string cerezKodu = Guid.NewGuid().ToString("n").Substring(0, 12);
                myUser.Cookie = cerezKodu;
                _userDal.Update(myUser);
                return Request.CreateResponse(HttpStatusCode.OK, cerezKodu);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Kullanıcı bulunamadı!");
            }
        }

        //Adres:  api/Service/Register
        [HttpPost]
        public HttpResponseMessage Register(UserRegisterDto register)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Geçerli kayıt yapınız!");

            User myUser = _userDal.GetEntitiesByFilter(x => x.Email == register.Email).FirstOrDefault();
            if(myUser == null)
            {
                myUser = new User();
                myUser.FirstName = register.FirstName;
                myUser.LastName = register.LastName;
                myUser.Email = register.Email;
                myUser.Password = register.Password;
                myUser.Phone = register.Phone;
                string cerezKodu = Guid.NewGuid().ToString("n").Substring(0, 12);
                myUser.Cookie = cerezKodu;
                _userDal.Add(myUser);
                return Request.CreateResponse(HttpStatusCode.OK, cerezKodu);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, register.Email + " adresiyle kayıt olunmuş!");
            }
        }

        //Adres: api/Service/Logout
        [HttpPost]
        public HttpResponseMessage Logout(string cookie)
        {
            if(cookie == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Çerez Gönderilmedi!");
            User myUser = _userDal.GetUserByCookie(cookie);
            if(myUser == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Kullanıcı bulunamadı!");
            }
            else
            {
                myUser.Cookie = null;
                _userDal.Update(myUser);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
    }
}
