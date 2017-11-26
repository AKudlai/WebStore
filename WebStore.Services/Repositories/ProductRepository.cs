namespace WebStore.Services.Repositories
{
    using System.Collections.Generic;

    using WebStore.Contructs;
    using WebStore.DAL;
    using WebStore.Domain.Entities;

    public class ProductRepository : IProductRepository
    {
        private readonly WebStoreContext context = new WebStoreContext();

        public IEnumerable<Product> Products => this.context.Products;
    }
}
