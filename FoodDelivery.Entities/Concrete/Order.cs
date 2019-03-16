using FoodDelivery.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Entities.Concrete
{
    public class Order : IEntity
    {
        [Key]
        public int ID { get; set; }
        public int AddressID { get; set; }
        public int BranchID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public bool PaymentType { get; set; }
        public bool IsActive { get; set; }

        public virtual Address Address { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }

        //public virtual Review Review { get; set; }
        //   public virtual Branch Branch { get; set; }

    }
}
