using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Entities.Concrete
{
    public class Branch
    {
        public int ID { get; set; }
        public int CompanyID { get; set; }
        public int RegionID { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }

        public virtual Company Company { get; set; }
        public virtual Region Region { get; set; }
      
    }
}
