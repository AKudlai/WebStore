namespace WebStore.WebUI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using WebStore.WebUI.Infrastructure.Abstract;
    using WebStore.WebUI.Models;

    public class AccountController : Controller
    {
        IAuthProvider authProvider;

        public AccountController(IAuthProvider auth)
        {
            this.authProvider = auth;
        }

        public ViewResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (this.ModelState.IsValid)
            {
                if (this.authProvider.Authenticate(model.UserName, model.Password))
                {
                    return this.Redirect(returnUrl ?? this.Url.Action("Index", "Admin"));
                }
                else
                {
                    this.ModelState.AddModelError(string.Empty, "Incorrect username or password");
                    return this.View();
                }
            }
            else
            {
                return this.View();
            }
        }
    }
}