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
        public IQueryable<ItemDetails> GetItemDetails()
        {
            return _ctx.ItemDetails;
        }
        public DbSet<MyCart> GetCarts()
        {
            return _ctx.Carts;
        }
        
    }
}