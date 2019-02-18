using FoodDelivery.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.Concrete.Mapping
{
    public class RegionMapping : EntityTypeConfiguration<Region>
    {
        public RegionMapping()
        {
            HasKey(x => x.ID);

            HasRequired(x => x.City).WithMany(x => x.Regions).HasForeignKey(x => x.CityID);
        }
    }
}
