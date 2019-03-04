using FoodDelivery.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Entities.Concrete
{
    public class City : IEntity
    {
        public int ID { get; set; }
        public string CityName { get; set; }

        public virtual List<Region> Regions { get; set; }
    }
}
