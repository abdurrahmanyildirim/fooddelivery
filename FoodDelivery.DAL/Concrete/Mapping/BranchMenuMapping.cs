using FoodDelivery.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.Concrete.Mapping
{
    class BranchMenuMapping : EntityTypeConfiguration<BranchMenu>
    {
        public BranchMenuMapping()
        {
            HasKey(x => x.ID);

            HasRequired(x => x.Branch).WithMany(x => x.BranchMenus).HasForeignKey(x => x.BranchID);
            HasRequired(x => x.Menu).WithMany(x => x.BranchMenus).HasForeignKey(x => x.MenuID);
        }
    }
}
