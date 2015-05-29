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
            CartItems = new CartItems();
        }
        
        [Key]
        public int Id { get; set; }
        public string MyCartId { get; set; }       
        //public double TaxRate { get; set; }
        public CartItems CartItems { get; set; }
        
    }
    [ComplexType]
    public class CartItems 
    {
        public int CartItemsId { get; set; }
        public string ItemString { get; set; }
        public string ItemCount { get; set; }  
    }
    
}