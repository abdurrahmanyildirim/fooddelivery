using FoodDelivery.Entities;
using FoodDelivery.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.Concrete.Mapping
{
    public class AddressMapping : EntityTypeConfiguration<Address>
    {
        public AddressMapping()
        {
            HasKey(x => x.ID);

            HasRequired(x => x.User).WithMany(x => x.Addresses).HasForeignKey(x => x.UserID);
            HasRequired(x => x.Region).WithMany(x => x.Addresses).HasForeignKey(x => x.RegionID);
        }
    }
}
