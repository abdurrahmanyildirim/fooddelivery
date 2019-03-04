using FoodDelivery.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Entities.Concrete
{
    public class OrderDetail : IEntity
    {
        public int ID { get; set; }
        public int MenuID { get; set; }
        public int OrderID { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual Order Order { get; set; }

    }
}
