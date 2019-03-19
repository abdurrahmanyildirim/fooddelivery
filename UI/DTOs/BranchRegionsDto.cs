using FoodDelivery.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.DTOs
{
    public class BranchRegionsDto
    {
        public List<Branch> Branches { get; set; }
        public List<Region> Regions { get; set; }
    }
}