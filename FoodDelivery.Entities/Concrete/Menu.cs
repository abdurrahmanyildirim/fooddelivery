using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Entities.Concrete
{
    public class Menu
    {
        public int ID { get; set; }
        public string MenuName { get; set; }
        public string MenuDetail { get; set; }
        public decimal Price { get; set; }
        public string PhotoPath { get; set; }

        public virtual ICollection<BranchMenu> BranchMenus { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
