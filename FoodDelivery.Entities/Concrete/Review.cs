using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Entities.Concrete
{
    public class Review
    {
        public int ID { get; set; }
        public int Point { get; set; }
        public string Comment { get; set; }

        public virtual Order Order { get; set; }
        
    }
}
