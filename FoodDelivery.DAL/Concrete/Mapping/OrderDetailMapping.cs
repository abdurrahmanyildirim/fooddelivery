using FoodDelivery.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.Concrete.Mapping
{
    public class OrderDetailMapping : EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailMapping()
        {
            HasKey(x => x.ID);
            Property(z => z.TotalAmount).HasColumnType("money");
            HasRequired(x => x.Menu).WithMany(x => x.OrderDetails).HasForeignKey(x => x.MenuID);
            HasRequired(x => x.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderID);
        }
    }
}
