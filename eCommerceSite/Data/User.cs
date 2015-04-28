using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eCommerceSite.Data
{
    public class User
    {
        public int Id{ get; set; }
        public int CreditCard { get; set; }
        public string Country { get; set; }
        public int CCExpMonth { get; set; }
        public int CCExpYear { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [InverseProperty("User")]
        public virtual IList<Order> Orders { get; set; }

        
        public virtual MyCart Cart { get; set; }
    }
}