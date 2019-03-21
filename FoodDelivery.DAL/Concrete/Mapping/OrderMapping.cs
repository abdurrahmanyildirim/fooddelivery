using FoodDelivery.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
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
            Property(c => c.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            Property(x => x.TotalPrice).HasColumnType("money");
            Property(x => x.OrderDate).HasColumnType("datetime2");

            HasRequired(x => x.Address).WithMany(x => x.Orders).HasForeignKey(x => x.AddressID);
        }
    }
}
