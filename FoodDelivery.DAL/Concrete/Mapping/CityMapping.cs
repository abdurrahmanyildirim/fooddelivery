using FoodDelivery.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.Concrete.Mapping
{
    class CityMapping :EntityTypeConfiguration<City>
    {
        public CityMapping()
        {
            HasKey(x => x.ID);
        }
    }
}
