using FoodDelivery.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Entities.Concrete
{
    public class Manager : IEntity
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cookie { get; set; }
    }
}
