namespace WebStore.WebUI.Models
{
    using WebStore.Domain.Entities;

    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }

        public string ReturnUrl { get; set; }
    }
}