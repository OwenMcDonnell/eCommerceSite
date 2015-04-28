using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eCommerceSite.Data
{
    public class Item
    {
        public int Id { get; set; }
        public byte[] Thumbnail { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public bool OnSale { get; set; }
        public string Description { get; set; }

        public virtual int OrderId { get; set; }
        [ForeignKey("OrderId")]
        [InverseProperty("Orders")]
        public virtual Order Order { get; set; }
        public virtual ItemDetails ItemDetails { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}