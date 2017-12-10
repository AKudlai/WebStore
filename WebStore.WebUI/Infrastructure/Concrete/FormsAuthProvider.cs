﻿namespace WebStore.WebUI.Infrastructure.Concrete
{
    using System.Web.Security;
    using WebStore.WebUI.Infrastructure.Abstract;

    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {
            bool result = FormsAuthentication.Authenticate(username, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }

            return result;
        }
    }
}