using FoodDelivery.DAL.Abstract.IRepository;
using FoodDelivery.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.Abstract
{
    public interface IMenuDal : IRepository<Menu>
    {
        ICollection<Menu> GetMenusByName(string menu);
        ICollection<Menu> GetMenusByCompanyID(int id);
        ICollection<Menu> GetMenusByCompanyCookie(string cookie);
        ICollection<Menu> GetMenusByNameOrCompany(string content);
    }
}
