using FoodDelivery.DAL.Abstract;
using FoodDelivery.DAL.Concrete.Repository;
using FoodDelivery.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.Concrete
{
    public class OrderDetailDal : EntityRepository<OrderDetail, Context>, IOrderDetailDal
    {
        public ICollection<OrderDetail> GetCartsByCookie(string cookie)
        {
            return GetEntitiesByFilter(x => x.Order.Address.User.Cookie == cookie && x.IsCompleted == false).ToList();
        }

        public OrderDetail GetCartByMenuUserOrder(int menuID,int userID,int orderID)
        {
            return Get(x => x.MenuID == menuID && x.OrderID == orderID && x.Order.Address.UserID == userID && x.IsCompleted == false);
        }
    }
}