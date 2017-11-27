namespace WebStore.WebUI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using WebStore.Contructs;
    using WebStore.Domain.Entities;
    using WebStore.WebUI.Models;

    public class ProductController : Controller
    {
        private readonly IProductRepository repository;

        public int PageSize = 4;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ViewResult List(int page = 1)
        {
            ProductListViewModel model = new ProductListViewModel
                                             {
                                                 Products =
                                                     this.repository.Products
                                                         .OrderBy(p => p.ProductId)
                                                         .Skip((page - 1) * this.PageSize)
                                                         .Take(this.PageSize),
                                                 PagingInfo =
                                                     new PagingInfo
                                                         {
                                                             CurrentPage = page,
                                                             ItemsPerPage =
                                                                 this.PageSize,
                                                             TotalItems =
                                                                 this.repository
                                                                     .Products.Count()
                                                         }
                                             };
            return this.View(model);
        }
    }
}