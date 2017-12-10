namespace WebStore.WebUI.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using WebStore.Contructs;
    using WebStore.Domain.Entities;
    using WebStore.WebUI.Models;

    public class ProductController : Controller
    {
        public int pageSize = 4;

        private readonly IProductRepository repository;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
                                              {
                                                  Products =
                                                      this.repository.Products
                                                          .Where(
                                                              p => category == null
                                                                   || p.Category == category)
                                                          .OrderBy(p => p.ProductId)
                                                          .Skip((page - 1) * this.pageSize)
                                                          .Take(this.pageSize),
                                                  PagingInfo =
                                                      new PagingInfo
                                                          {
                                                              CurrentPage = page,
                                                              ItemsPerPage =
                                                                  this.pageSize,
                                                              TotalItems =
                                                                  category == null
                                                                      ? this.repository
                                                                          .Products
                                                                          .Count()
                                                                      : this.repository
                                                                          .Products
                                                                          .Count(e => e.Category
                                                                                  == category)
                                                          },
                                                  CurentCategory = category
                                              };
            return this.View(model);
        }

        public FileContentResult GetImage(Guid productId)
        {
            Product prod = this.repository.Products
                .FirstOrDefault(p => p.ProductId == productId);
            if (prod != null)
            {
                return this.File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}