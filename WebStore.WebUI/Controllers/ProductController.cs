namespace WebStore.WebUI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using WebStore.Contructs;
    using WebStore.Domain.Entities;

    public class ProductController : Controller
    {
        private readonly IProductRepository repository;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ViewResult List()
        {
            return this.View(this.repository.Products);
        }
    }
}