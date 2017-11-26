namespace WebStore.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using WebStore.Domain.Entities;

    public class DBInitialiser : DropCreateDatabaseAlways<WebStoreContext>

    {
        protected override void Seed(WebStoreContext context)
        {
            context.Products.Add(new Product { ProductId = Guid.NewGuid(), Name = "Kayak", Category = "Watersports", Description = "А boat for one person", Price = 275M });
            context.Products.Add(new Product { ProductId = Guid.NewGuid(), Name = "Lifejacket", Category = "Watersports", Description = "Protective and fashionable", Price = 48.95M });
            context.Products.Add(new Product { ProductId = Guid.NewGuid(), Name = "Soccer Ball", Category = "Soccer", Description = "FIFA-approved size and weight", Price = 19.50M });
            context.Products.Add(new Product { ProductId = Guid.NewGuid(), Name = "Corner Flags", Category = "Soccer", Description = "Give your playing field аprofessional touch", Price = 34.95M });
            context.Products.Add(new Product { ProductId = Guid.NewGuid(), Name = "Stadium", Category = "Soccer", Description = "Flat-packed, 35, 000-seat staclium", Price = 79500.00M });
            context.Products.Add(new Product { ProductId = Guid.NewGuid(), Name = "Thinking Сар", Category = "Chess", Description = "Improve your brain efficiencyble 75%", Price = 16.00M });
            context.Products.Add(new Product { ProductId = Guid.NewGuid(), Name = "Unsteady Chair", Category = "Chess", Description = "Secretly give your opponent а disadvantage", Price = 29.95M });
            context.Products.Add(new Product { ProductId = Guid.NewGuid(), Name = "Human Chess Board", Category = "Chess", Description = "A fun game fo-r the family", Price = 16.00M });
            context.Products.Add(new Product { ProductId = Guid.NewGuid(), Name = "Bling-Bl.ing King", Category = "Chess", Description = "Gold-plated, diamond-studdedKing", Price = 1200.00M });
            base.Seed(context);
        }
    }
}
