using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eCommerceSite.Data
{
    public class eCommerceRepository
    {
        eCommerceContext _ctx;
        public eCommerceRepository()
        {
            _ctx = new eCommerceContext();
        }
        public IQueryable<Item> GetItems()
        {
            return _ctx.Items;
        }
        public IQueryable<Review> GetReviewsByItem(int ItemId)
        {
            return _ctx.Reviews.Where(r => r.Id == ItemId);
        }
        public DbSet<Item> GetObjects()
        {
            return _ctx.Items;
        }
        //public IQueryable<ItemDetails> GetItemDetails()
        //{
        //    return _ctx.Items.;
        //}
        public IQueryable<MyCart> GetCarts()
        {
            return _ctx.Carts;
            //if (_ctx.Carts.First() != null)
            //{
            //    return _ctx.Carts;
            //}
            //else
            //{
            //    _ctx.Carts.Add(new MyCart());
            //    _ctx.SaveChanges();
            //    return _ctx.Carts;
            //}
            
        }
        public void AddToCart(Item item)
        {
            _ctx.Carts.ItemsHash.Items.Add(item);
           
        }
        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }
        
    }
}