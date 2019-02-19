using FoodDelivery.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.Concrete.Mapping
{
    public class BranchMapping:EntityTypeConfiguration<Branch>
    {
        public BranchMapping()
        {
            HasKey(x => x.ID);

            HasRequired(x => x.Company).WithMany(x => x.Branches).HasForeignKey(x => x.CompanyID);
            HasRequired(x => x.Region).WithMany(x => x.Branches).HasForeignKey(x => x.RegionID);

        }
    }
}
