using FoodDelivery.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.DTOs
{
    public class MenuPointDto
    {

        public Menu Menu { get; set; }
        public int Point { get; set; }
        //public string MenuName { get; set; }
        //public decimal Price { get; set; }
        //public string Detail { get; set; }
        //public string CompanyName { get; set; }
    }
}