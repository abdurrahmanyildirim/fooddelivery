using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Entities.Concrete
{
    public class Company
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string PhotoPath { get; set; }
        public string Cookie { get; set; }

        public virtual ICollection<Branch> Branches { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
    }
}
