using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eCommerceSite.Data
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public System.DateTime OrderDate { get; set; }
        public string Name { get; set; }
        [Required()]
        [StringLength(16, MinimumLength=16, ErrorMessage = "Credit Card is not valid")] 
        public string CreditCard { get; set; }
        //public string Country { get; set; }
        [Required()]
        [Range(01, 12, ErrorMessage = "Expiry month is not valid")]
        public int CCExpMonth { get; set; }
        [Required()]
        [Range(1000, 9999, ErrorMessage = "Expiry year is not valid")]
        public int CCExpYear { get; set; }
        //[InverseProperty("Order")]
        public virtual List<Item> Items { get; set; }
        //public virtual int UserId { get; set; }
        //[ForeignKey("UserId")]
        //[InverseProperty("Orders")]
        //public virtual User User { get; set; }



    }
}