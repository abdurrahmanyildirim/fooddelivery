﻿using FoodDelivery.DAL.Abstract;
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
            return GetEntitiesByFilter(x => x.MenuName.ToLower().Contains(menu.ToLower()) || x.MenuDetail.ToLower().Contains(menu.ToLower())).ToList();
        }

        public ICollection<Menu> GetMenusByCompanyID(int id)
        {
            return GetEntitiesByFilter(x => x.CompanyID == id).ToList();
        }

        public ICollection<Menu> GetMenusByCompanyCookie(string cookie)
        {
            return GetEntitiesByFilter(x => x.Company.Cookie == cookie).ToList();
        }

        public ICollection<Menu> GetMenusByNameOrCompany(string content)
        {
            return GetEntitiesByFilter(x => x.MenuName.ToLower().Contains(content.ToLower()) || x.MenuDetail.ToLower().Contains(content.ToLower()) || x.Company.CompanyName.ToLower().Contains(content.ToLower())).ToList();
        }
    }
}