using FoodDelivery.DAL.Abstract.IRepository;
using FoodDelivery.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.Abstract
{
    public interface IAddressDal: IRepository<Address>
    {
        ICollection<Address> GetAddressByUserID(int userID);
    }
}
