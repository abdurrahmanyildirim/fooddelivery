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
using Newtonsoft.Json;

namespace UI.Controllers
{
    public class ServiceController : ApiController
    {
        IUserDal _userDal;
        IMenuDal _menuDal;
        IOrderDal _orderDal;
        IOrderDetailDal _orderDetailDal;
        public ServiceController()
        {
            _userDal = InstanceFactory.GetInstance<IUserDal>();
            _menuDal = InstanceFactory.GetInstance<IMenuDal>();
            _orderDal = InstanceFactory.GetInstance<IOrderDal>();
            _orderDetailDal = InstanceFactory.GetInstance<IOrderDetailDal>();
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

        [HttpPost]
        public HttpResponseMessage GetMenu([FromBody]MenuInfoDto gelenMenu)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID Olmalı");

            Menu menu = _menuDal.GetByID(gelenMenu.MenuID);
            if(menu == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Menü bulunamadı!");

            gelenMenu.MenuAdi = menu.MenuName;
            gelenMenu.MenuFiyati = menu.Price * gelenMenu.MenuAdedi;
            return Request.CreateResponse(HttpStatusCode.OK, gelenMenu);

        }

        [HttpPost]
        public HttpResponseMessage ConfirmOrder([FromBody]ConfirmOrderDto codto)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Hatali model!");
            string cookie = codto.Cookie;
            User user = _userDal.GetUserByCookie(cookie);
            if (user == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "User Bulunamadı!");

            List<List<int>> sepetArray = JsonConvert.DeserializeObject<List<List<int>>>(codto.OrderArray);
            int addressID = codto.AddressID;
            bool paymentType = codto.PaymentType == 0;
            decimal totalPrice = 0;
            
            int orderCount = sepetArray.Count;
            for (int i = 0; i < orderCount; i++)
            {
                totalPrice += (_menuDal.GetByID(sepetArray[i][0]).Price) * sepetArray[i][1];
            }

            Order o = new Order()
            {
                BranchID = sepetArray[0][2],
                AddressID = addressID,
                IsActive = true,
                OrderDate = DateTime.Now,
                PaymentType = paymentType,
                TotalPrice = totalPrice
            };
            _orderDal.Add(o);

            for (int i = 0; i < orderCount; i++)
            {
                OrderDetail od = new OrderDetail()
                {
                    IsCompleted = true,
                    MenuID = sepetArray[i][0],
                    OrderID = o.ID,
                    Quantity = sepetArray[i][1],
                    TotalAmount = _menuDal.GetByID(sepetArray[i][0]).Price * sepetArray[i][1]
                };
                _orderDetailDal.Add(od);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "Başarılı");
        }
    }
}
