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
    public class CompanyDal : EntityRepository<Company, Context>, ICompanyDal
    {
        public Company GetCompanyByLogin(string email, string password)
        {
            return Get(x => x.Email == email && x.Password == password);
        }

        public Company GetCompanyByCookie(string cookie)
        {
            return Get(x => x.Cookie == cookie);
        }
    }
}
