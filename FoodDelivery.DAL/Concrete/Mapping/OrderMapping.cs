using FoodDelivery.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.Concrete.Mapping
{
    public class OrderMapping : EntityTypeConfiguration<Order>
    {
        public OrderMapping()
        {
            HasKey(x => x.ID);
            Property(x => x.TotalPrice).HasColumnType("money");
            Property(x => x.OrderDate).HasColumnType("datetime2");

            HasRequired(x => x.User).WithMany(x => x.Orders).HasForeignKey(x => x.UserID);
            HasRequired(x => x.Address).WithMany(x => x.Orders).HasForeignKey(x => x.AddressID);
        }
    }
}
