using eCommerceSite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerceSite.Models
{
    public class MyCartModel
    {
        eCommerceRepository rep = new eCommerceRepository();
        public static MyCart GetCart(HttpContextBase context)
        {
            var cart = new MyCart();
            var cartModel = new MyCartModel();
            cart.MyCartId = cartModel.GetCartId(context);
            return cart;
        }
        public string GetCartId(HttpContextBase context)
        {
            Guid tempCartId = Guid.NewGuid();
            context.Session["CartId"] = tempCartId.ToString();
            return context.Session["CartId"].ToString();
        }
        
        public void AddToCart(Item item, HttpContextBase context)
        {
            var cart = rep.GetCarts().SingleOrDefault(c => c.MyCartId == context.Session["CartId"]);
            
            int currentCount;
            cart.ItemsHash.TryGetValue(item, out currentCount);
            
            cart.ItemsHash[item] = currentCount + 1;      
        }
        public void RemoveFromCart(Item item, HttpContextBase context)
        {
            var cart = rep.GetCarts().SingleOrDefault(c => c.MyCartId == context.Session["CartId"]);
            int currentCount;

            if (cart.ItemsHash.TryGetValue(item, out currentCount))
            {
                cart.ItemsHash[item] = currentCount - 1;   
            }
            
        }
        public List<Item> GetCartItems(HttpContextBase context)
        {
            var cart = rep.GetCarts().SingleOrDefault(c => c.MyCartId == context.Session["CartId"]);
            return cart.ItemsHash.Keys.ToList();
        }
        public decimal GetCartTotal(HttpContextBase context)
        {
            var cart = rep.GetCarts().SingleOrDefault(c => c.MyCartId == context.Session["CartId"]);
            decimal total = 0;
            foreach (Item item in cart.ItemsHash.Keys)
            {
                total += item.Price * cart.ItemsHash[item];
            }
            return total;
        }
        public int CreateOrder(Order order, HttpContextBase context)
        {
            var cart = rep.GetCarts().SingleOrDefault(c => c.MyCartId == context.Session["CartId"]);
            decimal total = 0;
            foreach (Item item in cart.ItemsHash.Keys)
            {
                total += item.Price * cart.ItemsHash[item];
            }
            order.Total = total;
            foreach (Item item in cart.ItemsHash.Keys)
            {
                for (int i = 0; i < cart.ItemsHash[item]; i++)
                {
                    order.Items.Add(item);
                }
            }
            order.OrderDate = DateTime.Now;
            order.UserId = cart.UserId;
            return order.Id;
        }


    }
}