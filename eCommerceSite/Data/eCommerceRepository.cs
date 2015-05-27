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
        public void AddToCart(Item item, string id)
        {
            
            var cart = ctx.Carts.Where(c => c.MyCartId == id).Single();
            Item[] arr = cart.ItemsHash.Items;
            int[] arr2 = cart.ItemsHash.Count;
            Array.Resize(ref arr, 1);
            Array.Resize(ref arr2, 1);
            arr[arr.Length - 1] = item;
            arr2[arr2.Length - 1] = 1;
            ctx.SaveChanges();
        }
        public void AddCart(MyCart cart)
        {
            ctx.Carts.Add(cart);
            ctx.SaveChanges();
        }
        public void CartCountInc(MyCart cart, Item item)
        {
            cart.ItemsHash.Count[Array.IndexOf(cart.ItemsHash.Items, item)] += 1;
            ctx.SaveChanges();
        }
        //public IQueryable<ItemDetails> GetItemDetails()
        //{
        //    return _ctx.Items.;
        //}
        
    }
}