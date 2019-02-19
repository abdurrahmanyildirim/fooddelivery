using FoodDelivery.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.Concrete.Mapping
{
    public class MenuMapping : EntityTypeConfiguration<Menu>
    {
        public MenuMapping()
        {
            HasKey(x => x.ID);
            Property(x => x.Price).HasColumnType("money");


        }
    }
}
