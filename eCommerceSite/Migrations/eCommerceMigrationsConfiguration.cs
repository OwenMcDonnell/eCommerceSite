namespace eCommerceSite.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class eCommerceMigrationsConfiguration : DbMigrationsConfiguration<eCommerceSite.Data.eCommerceContext>
    {
        public eCommerceMigrationsConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(eCommerceSite.Data.eCommerceContext context)
        {
              //This method will be called after migrating to the latest version.

              //You can use the DbSet<T>.AddOrUpdate() helper extension method 
              //to avoid creating duplicate seed data. E.g.
            
                //context.Items.AddOrUpdate(
                //  I => I.FullName,
                //  new Item { FullName = "Andrew Peters" },
                //  new Person { FullName = "Brice Lambson" },
                //  new Person { FullName = "Rowan Miller" }
                //);
            
        }
    }
}
