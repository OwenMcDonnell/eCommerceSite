using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eCommerceSite.Data
{
    public class MyCart
    {
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string MyCartId { get; set; }
        public IDictionary<Item, int> ItemsHash { get; set; }
        
        public int TaxRate { get; set; }
    
        
    }
}