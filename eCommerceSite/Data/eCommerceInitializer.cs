using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace eCommerceSite.Data
{
    public class eCommerceInitializer : DropCreateDatabaseAlways<eCommerceContext>
    {
        
            
        

        protected override void Seed(eCommerceContext context)
        {
            
            var items = new List<Item> 
            {
                new Item {Name="Men's Parka", Description="A wonderful jacket to wear in the cold!", OnSale=false, Price=59.65M, Thumbnail=context.imageToByteArray(Image.FromFile(@"F:\Programming\Visualstudio projects\eCommerceSite\eCommerceSite\Images\goods_25_139275.jpeg"))},
                new Item {Name="Men's Light Hooded", Description="Great for a chilly spring or fall day!", OnSale=false, Price=39.99M, Thumbnail=context.imageToByteArray(Image.FromFile(@"F:\Programming\Visualstudio projects\eCommerceSite\eCommerceSite\Images\goods_59_139291.jpg"))},
                new Item {Name="Men's Waterproof Pocketable", Description="Packs away compactly for that unexpected rain storm!", OnSale=true, Price=38.95M, Thumbnail=context.imageToByteArray(Image.FromFile(@"F:\Programming\Visualstudio projects\eCommerceSite\eCommerceSite\Images\goods_64_139257.jpeg"))}
            };
            items.ForEach(i => context.Items.Add(i));
            context.SaveChanges();
        }
    }

   
}