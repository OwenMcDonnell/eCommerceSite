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
        //public MyCart()
        //{
        //    _ItemsHash = new ItemsHash();
        //}
        
        [Key]
        public int Id { get; set; }
        public string MyCartId { get; set; }
        public ItemsHash ItemsHash { get; set; }
        //public ItemsHash ItemsHash
        //{
        //    get { return _ItemsHash; }
        //    set { _ItemsHash = value; }
        //}
        public int TaxRate { get; set; } 
        
    }
    [ComplexType]
    public class ItemsHash
    {
        public int ItemsHashId { get; set; }
        public List<Item> Items { get; set; }
        public List<int> Count { get; set; }

    }
}