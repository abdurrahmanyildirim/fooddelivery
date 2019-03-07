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
    public class MenuDal : EntityRepository<Menu, Context>, IMenuDal
    {
        public ICollection<Menu> GetMenusByName(string menu)
        {
            return GetEntitiesByFilter(x => x.MenuName.Contains(menu) || x.MenuDetail.Contains(menu)).ToList();
        }
    }
}
