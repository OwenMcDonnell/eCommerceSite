using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerceSite.Data
{
    public interface IeCommerceRepository
    {
        IQueryable<Item> GetItems();
        void AddItem(Item item);
        MyCart GetMyCart(string id);
        void AddToCart(Item item, string id);
        IQueryable<Review> GetReviewsByItem(int id);
        void CartCountInc(MyCart cart, Item item);
    }
}