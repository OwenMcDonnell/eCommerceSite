using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eCommerceSite.Data
{
    public interface IeCommerceRepository
    {
        IQueryable<Item> GetItems();
        void AddItem(Item item);
        MyCart GetMyCart(string id);
        void AddToCart(Item item, MyCart cart);
        IQueryable<Review> GetReviewsByItem(int id);
        void CartCountInc(MyCart cart, Item item);
        void AddCart(MyCart cart);
        DbSet<MyCart> GetCarts();
    }
}