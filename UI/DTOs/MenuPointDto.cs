using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.DTOs
{
    public class MenuPointDto
    {
        public string MenuName { get; set; }
        public int Point { get; set; }
        public decimal Price { get; set; }
        public string Detail { get; set; }
    }
}