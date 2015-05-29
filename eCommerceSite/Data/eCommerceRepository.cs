using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eCommerceSite.Data
{
    public class eCommerceRepository : IeCommerceRepository
    {
        eCommerceContext ctx;
        public eCommerceRepository()
        {
            ctx = new eCommerceContext();
        }
        public IQueryable<Item> GetItems()
        {
            return ctx.Items;
        }
        public IQueryable<Review> GetReviewsByItem(int id)
        {
            return ctx.Reviews.Where(r => r.Id == id);
        }
        public DbSet<Item> GetObjects()
        {
            return ctx.Items;
        }
        public DbSet<MyCart> GetCarts()
        {
            return ctx.Carts;
        }
        public void AddItem(Item item)
        {
            ctx.Items.Add(item);
            ctx.SaveChanges();
        }
        public MyCart GetMyCart(string id)
        {
            return ctx.Carts.Where(c => c.MyCartId == id).Single();
        }
        public void AddToCart(Item item, MyCart cart)
        {         
            //var cart = ctx.Carts.Where(c => c.MyCartId == id).Single();
            cart.CartItems.ItemString += item.Name;
            cart.CartItems.ItemString += ";";
            //cart.CartItems.ItemCount += 1;
            //cart.CartItems.ItemCount += ";";
            ctx.SaveChanges();
        }
        public void CartCountInc(MyCart cart, Item item)
        {
            if (cart.CartItems.ItemCount == null)
            {
                cart.CartItems.ItemCount += "1";
                cart.CartItems.ItemCount += ";";
            }
            else
            {
                List<int> itemsCount = cart.CartItems.ItemCount.Split(new char[] {';'}, 
                    StringSplitOptions.RemoveEmptyEntries).Select(c => Int32.Parse(c)).ToList();
                List<string> itemsList = cart.CartItems.ItemString.Split(new char[] {';'}, 
                    StringSplitOptions.RemoveEmptyEntries).ToList();
                if (itemsCount.Count > itemsList.IndexOf(item.Name))
                {
                    itemsCount[itemsList.IndexOf(item.Name)] += 1;
                    cart.CartItems.ItemCount = String.Join(";", itemsCount);
                }
                else
                {
                    itemsCount.Add(1);
                    cart.CartItems.ItemCount = String.Join(";", itemsCount);
                }
                
            }
            
            ctx.SaveChanges();
        }
        public void AddCart(MyCart cart)
        {
            ctx.Carts.Add(cart);
            ctx.SaveChanges();
        }
        
        //public IQueryable<ItemDetails> GetItemDetails()
        //{
        //    return _ctx.Items.;
        //}
        
    }
}