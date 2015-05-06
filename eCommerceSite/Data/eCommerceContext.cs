using eCommerceSite.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eCommerceSite.Data
{
    public class eCommerceContext : DbContext
    {
        public eCommerceContext() : base("DefaultConnection")
        {
            //this.Configuration.LazyLoadingEnabled = false;
            //this.Configuration.ProxyCreationEnabled = false;

            //Database.SetInitializer(
            //    new MigrateDatabaseToLatestVersion<eCommerceContext, eCommerceMigrationsConfiguration>()
            //    );
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Review> Reviews { get; set; }
        //public DbSet<ItemDetails> ItemDetails { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<TaxRate> TaxRates { get; set; }
        public DbSet<MyCart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }


    }
}