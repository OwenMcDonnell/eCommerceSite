using System;
using System.Collections.Generic;
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
        public int CreditCard { get; set; }
        public string Country { get; set; }
        public int CCExpMonth { get; set; }
        public int CCExpYear { get; set; }
        //[InverseProperty("Order")]
        public virtual IList<Item> Items { get; set; }
        public virtual int UserId { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("Orders")]
        public virtual User User { get; set; }



    }
}