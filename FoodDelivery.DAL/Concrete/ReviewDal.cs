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
    public class ReviewDal : EntityRepository<Review, Context>, IReviewDal
    {
        public ICollection<Review> GetReviewsByMenu(int id)
        {
            return GetEntitiesByFilter(x => x.MenuID == id).ToList();
        }
    }
}
