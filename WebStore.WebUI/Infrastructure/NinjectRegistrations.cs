namespace WebStore.WebUI.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Moq;

    using Ninject.Modules;

    using WebStore.Contructs;
    using WebStore.Domain.Entities;

    public class NinjectRegistrations : NinjectModule 

    {
        public override void Load()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(
                new List<Product>
                    {
                        new Product { Name = "FootЬall", Price = 25 },
                        new Product { Name = "Surfboard", Price = 179 },
                        new Product { Name = "Running shoes", Price = 95 }
                    });
            this.Kernel.Bind<IProductRepository>().ToConstant(mock.Object);
        }
    }
}