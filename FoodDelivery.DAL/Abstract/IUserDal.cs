using FoodDelivery.DAL.Abstract.IRepository;
using FoodDelivery.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.Abstract
{
    public interface IUserDal:IRepository<User>
    {
        IQueryable<User> GetNameByFilter(string filter);

        User GetUserByLogin(string userName, string password);

        User GetUserByCookie(string cookie);
    }
}
