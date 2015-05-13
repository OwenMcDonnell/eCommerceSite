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
        string _CartId { get; set; }
        public static MyCartModel GetCart(HttpContextBase context)
        {
            var cart = new MyCartModel();
            //var cartModel = new MyCartModel();
            cart._CartId = cart.GetCartId(context);
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
            if (rep.GetCarts().Single(c => c.MyCartId == _CartId).ToString() != "")
            {
                MyCart cart = rep.GetCarts().SingleOrDefault(c => c.MyCartId == context.Session["CartId"]);
                if (cart.ItemsHash.Items.Contains(item))
                {
                    cart.ItemsHash.Count[cart.ItemsHash.Items.IndexOf(item)] += 1;
                    
                }
                else
                {
                    cart.ItemsHash.Items.Add(item);
                    cart.ItemsHash.Count.Add(1);
                }
            }
            else
            {
                MyCart cart = new MyCart();
                MyCartModel.GetCart(context);
                rep.GetCarts().Add(cart);
                cart.MyCartId = _CartId;
                cart.ItemsHash = new ItemsHash();
                cart.ItemsHash.Items = new List<Item>();
                cart.ItemsHash.Items.Add(item);
                cart.ItemsHash.Count = new List<int>();
                cart.ItemsHash.Count.Add(1);
                //if (cart.ItemsHash.Items.Contains(item))
                //{
                //    cart.ItemsHash.Count[cart.ItemsHash.Items.IndexOf(item)] += 1;
                //}
                //else
                //{
                //    cart.ItemsHash.Items.Add(item);
                //    cart.ItemsHash.Count.Add(1);
                //}
                rep.SaveChanges();
            }
           
            rep.SaveChanges();
            
            //int currentCount;
            //cart.ItemsHash.TryGetValue(item, out currentCount);
            
            //cart.ItemsHash[item] = currentCount + 1;      
        }
        public void RemoveFromCart(Item item, HttpContextBase context)
        {
            var cart = rep.GetCarts().SingleOrDefault(c => c.MyCartId == context.Session["CartId"]);
            //int currentCount;

            if (cart.ItemsHash.Count[cart.ItemsHash.Items.IndexOf(item)] > 1)
            {
                cart.ItemsHash.Count[cart.ItemsHash.Items.IndexOf(item)] -= 1;   
            }
            else
            {
                cart.ItemsHash.Count.RemoveAt(cart.ItemsHash.Items.IndexOf(item));
                cart.ItemsHash.Items.Remove(item);
            }
            
        }
        public List<Item> GetCartItems(HttpContextBase context)
        {
            //var cart = rep.GetCarts().SingleOrDefault(c => c.MyCartId == context.Session["CartId"]);
            if (rep.GetCarts().Contains(new MyCart { MyCartId = _CartId }))
            {
                MyCart cart = rep.GetCarts().SingleOrDefault(c => c.MyCartId == context.Session["CartId"]);
                return cart.ItemsHash.Items;
            }
            else
            {
                return null;
            }
           
        }
        public decimal GetCartTotal(HttpContextBase context)
        {
            var cart = rep.GetCarts().SingleOrDefault(c => c.MyCartId == context.Session["CartId"]);
            decimal total = 0;
            foreach (Item item in cart.ItemsHash.Items)
            {
                total += item.Price * cart.ItemsHash.Count[cart.ItemsHash.Items.IndexOf(item)];
            }
            return total;
        }
        public int CreateOrder(Order order, HttpContextBase context)
        {
            var cart = rep.GetCarts().SingleOrDefault(c => c.MyCartId == context.Session["CartId"]);
            decimal total = 0;
            foreach (Item item in cart.ItemsHash.Items)
            {
                total += item.Price * cart.ItemsHash.Count[cart.ItemsHash.Items.IndexOf(item)];
            }
            order.Total = total;
            foreach (Item item in cart.ItemsHash.Items)
            {
                for (int i = 0; i < cart.ItemsHash.Count[cart.ItemsHash.Items.IndexOf(item)]; i++)
                {
                    order.Items.Add(item);
                }
            }
            order.OrderDate = DateTime.Now;
            order.UserId = cart.Id;
            return order.Id;
        }


    }
}