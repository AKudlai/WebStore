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

    public class CartController : Controller
    {
        private readonly IProductRepository repository;

        private readonly IOrderProcessor orderProcessor;

        public CartController(IProductRepository repository, IOrderProcessor orderProcessor)
        {
            this.repository = repository;
            this.orderProcessor = orderProcessor;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return this.View(new CartIndexViewModel
                            {
                                Cart = cart,
                                ReturnUrl = returnUrl
                            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, Guid productId, string returnUrl)
        {
            Product product = this.repository.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return this.RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, Guid productId, string returnUrl)
        {
            Product product = this.repository.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return this.RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return this.PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return this.View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                this.ModelState.AddModelError(string.Empty, "Sorry, your cart is empty!");
            }
            if (this.ModelState.IsValid)
            {
                this.orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return this.View("Completed");
            }
            else
            {
                return this.View(shippingDetails);
            }
        }
    }
}