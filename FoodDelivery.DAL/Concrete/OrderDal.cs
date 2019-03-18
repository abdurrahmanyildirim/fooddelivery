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
    public class OrderDal : EntityRepository<Order, Context>, IOrderDal
    {
        public Order GetActiveOrderByUser(int id)
        {
            return Get(x => x.Address.UserID == id && x.IsActive == true);
        }

        public ICollection<Order> GetOrdersByUserID(int id)
        {
            return GetEntitiesByFilter(x => x.Address.UserID == id).ToList();
        }
    }
}
