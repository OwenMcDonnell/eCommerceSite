using eCommerceSite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerceSite.Models
{
    public class MyCartViewModel
    {
        public List<MyCart> MyCarts { get; set; }
        public decimal CartTotal { get; set; }
    }
}