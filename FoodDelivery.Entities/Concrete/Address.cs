using FoodDelivery.Entities.Abstract;
using FoodDelivery.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Entities
{
    public class Address : IEntity
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int RegionID { get; set; }
        public string AddressDetail { get; set; }
        public string Title { get; set; }

        public virtual User User { get; set; }
        public virtual Region Region { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
