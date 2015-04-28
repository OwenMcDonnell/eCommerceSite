using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerceSite.Data
{
    public class TaxRate
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public decimal Rate { get; set; }

    }
}