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

        public CartController(IProductRepository repo)
        {
            this.repository = repo;
        }

        public ViewResult Index(string returnUrl)
        {
            return this.View(new CartIndexViewModel
                            {
                                Cart = this.GetCart(),
                                ReturnUrl = returnUrl
                            });
        }

        public RedirectToRouteResult AddToCart(Guid productId, string returnUrl)
        {
            Product product = this.repository.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                this.GetCart().AddItem(product, 1);
            }
            return this.RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Guid productId, string returnUrl)
        {
            Product product = this.repository.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                this.GetCart().RemoveLine(product);
            }
            return this.RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)this.Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                this.Session["Cart"] = cart;
            }
            return cart;
        }
    }
}