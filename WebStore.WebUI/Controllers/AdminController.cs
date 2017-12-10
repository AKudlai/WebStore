namespace WebStore.WebUI.Controllers
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using WebStore.Contructs;
    using WebStore.Domain.Entities;

    [Authorize]
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
        public ActionResult Edit(Product product, HttpPostedFileBase image = null)
            {
            if (this.ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
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