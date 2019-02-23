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
    public class CompanyApplyDal : EntityRepository<CompanyApply, Context>,ICompanyApplyDal
    {
        public IQueryable<CompanyApply> GetActiveApplies()
        {
            return GetEntitiesByFilter(x => x.IsActive == true);
        }
    }
}
