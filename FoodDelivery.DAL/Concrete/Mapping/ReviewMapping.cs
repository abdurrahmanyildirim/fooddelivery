using FoodDelivery.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.Concrete.Mapping
{
    public class ReviewMapping : EntityTypeConfiguration<Review>
    {
        public ReviewMapping()
        {
            HasKey(x => x.ID);

            HasRequired(x => x.Menu).WithMany(x => x.Reviews).HasForeignKey(x => x.MenuID);
            
        }
    }
}
