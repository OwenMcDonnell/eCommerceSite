using eCommerceSite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerceSite.Models
{
    public class MyCartViewModel
    {
        public List<Item> CartItems { get; set; }
        public List<string> ItemTotals { get; set; }
        public decimal CartTotal { get; set; }
    }
}