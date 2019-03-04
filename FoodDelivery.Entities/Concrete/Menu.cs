using FoodDelivery.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Entities.Concrete
{
    public class Menu : IEntity
    {
        public int ID { get; set; }
        public int CompanyID { get; set; }
        public string MenuName { get; set; }
        public string MenuDetail { get; set; }
        public decimal Price { get; set; }
        public string PhotoPath { get; set; }

        //public virtual ICollection<BranchMenu> BranchMenus { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Company Company { get; set; }
    }
}
