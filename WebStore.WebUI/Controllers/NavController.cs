namespace WebStore.WebUI.Controllers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using WebStore.Contructs;
    using WebStore.Domain.Entities;

    public class NavController : Controller
    {
        private IProductRepository repository;

        public NavController(IProductRepository repository)
        {
            this.repository = repository;
        }
        // GET: Nav
        public PartialViewResult Menu(string category = null, bool horizontalLayout = false)
        {
            this.ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = this.repository.Products.Select(x => x.Category).Distinct().OrderBy(x => x);
            string viewName = horizontalLayout ? "MenuHorizontal" : "Menu";
            return this.PartialView(viewName, categories);
        }
    }
}