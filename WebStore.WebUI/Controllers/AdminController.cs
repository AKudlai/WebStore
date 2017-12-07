namespace WebStore.WebUI.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using WebStore.Contructs;
    using WebStore.Domain.Entities;

    public class AdminController : Controller
    {
        private readonly IProductRepository repository;

        public AdminController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index()
        {
            return this.View(this.repository.Products);
        }

        public ViewResult Edit(Guid productId)
        {
            Product product = this.repository.Products
                .FirstOrDefault(p => p.ProductId == productId);
            return this.View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (this.ModelState.IsValid)
            {
                this.repository.SaveProduct(product);
                this.TempData["message"] = $"{product.Name} has been saved";
                return this.RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return this.View(product);
            }
        }

        public ViewResult Create()
        {
            return this.View("Edit", new Product());
        }

        [HttpPost]
        public ActionResult Delete(Guid productId)
        {
            Product deletedProduct = this.repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                this.TempData["message"] = $"{deletedProduct.Name} was deleted";
            }
            return this.RedirectToAction("Index");
        }
    }
}