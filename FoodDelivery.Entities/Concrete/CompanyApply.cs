using FoodDelivery.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Entities.Concrete
{
    public class CompanyApply : IEntity
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
