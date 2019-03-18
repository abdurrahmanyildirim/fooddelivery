using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.DTOs
{
    public class ConfirmOrderDto
    {
        public string Cookie { get; set; }
        public string OrderArray { get; set; }
        public int AddressID { get; set; }
        public int PaymentType { get; set; }
    }
}