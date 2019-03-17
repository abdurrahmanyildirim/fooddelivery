using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.DTOs
{
    public class MenuInfoDto
    {
        public int MenuID { get; set; }
        public string MenuAdi { get; set; }
        public decimal MenuFiyati { get; set; }
        public int MenuAdedi { get; set; }
    }
}