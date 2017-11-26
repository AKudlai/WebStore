namespace WebStore.DAL
{
    using System.Data.Entity;
    using WebStore.Domain.Entities;

    public class WebStoreContext : DbContext
    {
        public WebStoreContext()
            : base("WebStore")
        {
            Database.SetInitializer(new DBInitialiser());
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Product> Products { get; set; }


    }
}
