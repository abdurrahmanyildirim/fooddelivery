using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Entities.Concrete
{
    public class BranchMenu
    {
        public int ID { get; set; }
        public int BranchID { get; set; }
        public int MenuID { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
