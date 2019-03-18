using FoodDelivery.DAL.Abstract;
using FoodDelivery.DAL.Concrete.Repository;
using FoodDelivery.Entities;
using FoodDelivery.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.Concrete
{
    public class AddressDal : EntityRepository<Address, Context>, IAddressDal
    {
        public ICollection<Address> GetAddressByUserID(int userID)
        {
            return GetEntitiesByFilter(x => x.UserID == userID).ToList();
        }
    }
}
