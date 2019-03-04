using FoodDelivery.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Entities.Concrete
{
    public class Region : IEntity
    {
        public int ID { get; set; }
        public int CityID { get; set; }
        public string RegionName { get; set; }

        public virtual City City { get; set; }
        public virtual List<Branch> Branches { get; set; }
        public virtual List<Address> Addresses { get; set; }
    }
}
