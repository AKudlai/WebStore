namespace WebStore.WebUI
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Ninject;
    using Ninject.Modules;
    using Ninject.Web.Mvc;

    using WebStore.Contructs;
    using WebStore.Domain.Entities;
    using WebStore.Services;
    using WebStore.WebUI.Infrastructure;
    using WebStore.WebUI.Infrastructure.Abstract;
    using WebStore.WebUI.Infrastructure.Binders;
    using WebStore.WebUI.Infrastructure.Concrete;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Dependency ijection
            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);
            kernel.Unbind<ModelValidatorProvider>();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());

            EmailSettings emailSettings = new EmailSettings
                                              {
                                                  WriteAsFile = bool.Parse(
                                                      ConfigurationManager.AppSettings[
                                                          "Email.WriteAsFile"] ?? "false")
                                              };
            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("settings", emailSettings);
            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}
