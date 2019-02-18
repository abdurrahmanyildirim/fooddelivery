using FoodDelivery.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.Concrete.Mapping
{
    public class UserMapping:EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            HasKey(x => x.ID);
        }
    }
}
