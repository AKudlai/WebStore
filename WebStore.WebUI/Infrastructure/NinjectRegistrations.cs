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
    using WebStore.Services.Repositories;

    public class NinjectRegistrations : NinjectModule 

    {
        public override void Load()
        {
            this.Kernel.Bind<IProductRepository>().To<ProductRepository>();
        }
    }
}