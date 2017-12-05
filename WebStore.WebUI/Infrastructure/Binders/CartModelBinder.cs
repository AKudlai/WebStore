namespace WebStore.WebUI.Infrastructure.Binders

{
    using System.Web.Mvc;

    using WebStore.Domain.Entities;

    public class CartModelBinder : IModelBinder
    {
        private const string SessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // Получить объект Cart из сеанса
            Cart cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (Cart)controllerContext.HttpContext.Session[SessionKey];
            }

            // Создать экземпляр Cart, если он не обнаружен в данных сеанса
            if (cart == null)
            {
                cart = new Cart();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[SessionKey] = cart;
                }
            }

            // return the cart
            return cart;
        }
    }
}