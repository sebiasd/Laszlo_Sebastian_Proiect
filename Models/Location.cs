using System.ComponentModel.DataAnnotations;

namespace Laszlo_Sebastian_Proiect.Models
{
    public class Location
    {
        public int ID { get; set; }

        [Display(Name = "City")]
        [RegularExpression("^[A-Z][a-z]*$", ErrorMessage = "City must start with an uppercase letter.")]
        public string LocationName { get; set; }

        public string Description { get; set; }

        public ICollection<Tattoo>? Tattoos { get; set; }
    }
}
