using eCommerceSite.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
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
            
            

        }
        
        public DbSet<Item> Items { get; set; }
        public DbSet<Review> Reviews { get; set; }
        //public DbSet<ItemDetails> ItemDetails { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<TaxRate> TaxRates { get; set; }
        public DbSet<MyCart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }



        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
    }
}