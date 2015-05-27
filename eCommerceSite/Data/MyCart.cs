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
        public MyCart()
        {
            ItemsHash = new ItemsHash();
            ItemsHash.Items = new Item[]{};
            ItemsHash.Count = new int[]{};
            this.ItemsHash = ItemsHash;
        }
        
        [Key]
        public int Id { get; set; }
        public string MyCartId { get; set; }
        public ItemsHash ItemsHash { get; set; }       
        public int TaxRate { get; set; } 
        
    }
    [ComplexType]
    public class ItemsHash
    {
        public int ItemsHashId { get; set; }
        public Item[] Items { get; set; }
        public int[] Count { get; set; }

    }
}