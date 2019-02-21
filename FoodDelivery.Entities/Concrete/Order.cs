using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Entities.Concrete
{
    public class Order
    {
        public int ID { get; set; }
        public int AddressID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public bool PaymentType { get; set; }
        public bool IsActive { get; set; }

        public virtual Address Address { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
        public virtual Review Review { get; set; }

    }
}
