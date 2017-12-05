namespace WebStore.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class ShippingDetails
    {
        [Required(ErrorMessage = "Please enter a name")] // Введите имя
        public string Name { get; set; }

        // Введите первую строку адреса
        [Required(ErrorMessage = "Please enter the first address line")]

        [Display(Name = "Line 1")]
        public string Line1 { get; set; }

        [Display(Name = "Line 2")]
        public string Line2 { get; set; }

        [Display(Name = "Line 3")]
        public string Line3 { get; set; }

        // Введите название города
        [Required(ErrorMessage = "Please enter a city name")]
        public string City { get; set; }

        // Введите название штата
        [Required(ErrorMessage = "Please enter a state name")]
        public string State { get; set; }

        public string Zip { get; set; }

        // Введите название страны
        [Required(ErrorMessage = "Please enter a country name")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }
    }
}
