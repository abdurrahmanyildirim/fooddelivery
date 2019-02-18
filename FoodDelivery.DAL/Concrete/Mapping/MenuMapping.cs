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

            HasRequired(x => x.Branch).WithMany(x => x.Menus).HasForeignKey(x => x.BranchID);
            HasRequired(x => x.Company).WithMany(x => x.Menus).HasForeignKey(x => x.CompanyID);
        }
    }
}
