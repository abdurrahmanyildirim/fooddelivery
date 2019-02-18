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
        public int BranchID { get; set; }
        public int CompanyID { get; set; }
        public string MenuName { get; set; }
        public string MenuDetail { get; set; }
        public decimal Price { get; set; }

        public Branch Branch { get; set; }
        public Company Company { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

    }
}
