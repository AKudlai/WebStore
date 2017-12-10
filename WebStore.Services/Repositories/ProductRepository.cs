namespace WebStore.Services.Repositories
{
    using System;
    using System.Collections.Generic;

    using WebStore.Contructs;
    using WebStore.DAL;
    using WebStore.Domain.Entities;

    public class ProductRepository : IProductRepository
    {
        private readonly WebStoreContext context = new WebStoreContext();

        public IEnumerable<Product> Products => this.context.Products;

        public void SaveProduct(Product product)
        {
            if (product.ProductId == Guid.Empty)
            {
                this.context.Products.Add(product);
            }
            else
            {
                Product dbEntry = this.context.Products.Find(product.ProductId);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                    dbEntry.ImageData = product.ImageData;
                    dbEntry.ImageMimeType = product.ImageMimeType;
                }
            }

            this.context.SaveChanges();
        }

        public Product DeleteProduct(Guid productId)
        {
            Product dbEntry = this.context.Products.Find(productId);
            if (dbEntry != null)
            {
                this.context.Products.Remove(dbEntry);
                this.context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
