using System.ComponentModel.DataAnnotations;

namespace Laszlo_Sebastian_Proiect.Models
{
    public class Tattoo
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        [RegularExpression(@"^[A-Z][a-z]*([-\s][A-Z][a-z]*)*$", ErrorMessage = "Each part of the full name must start with an uppercase letter (e.g., John Smith or John David Smith)")]
        public string ClientName { get; set; }

        [Required]
        public string Email { get; set; }

        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Phone number must be formatfed like this '0722-123-123' or '0722.123.123' or '0722 123 123'")]
        public string? Phone{ get; set; }

        [Required]
        public int? LocationID { get; set; }

        [Display(Name = "Location")]

        public Location? Location { get; set; }

        [Required]
        [Display(Name = "Tattoo Artist")]
        public int? TattooArtistID { get; set; }
        public TattooArtist? TattooArtist { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Prefferd Date")]
        public DateTime Date { get; set; }

        [Display(Name = "I am 18 years or older")]
        public bool AgeConfirmation { get; set; }

        
        public int StyleID { get; set; }
        public Style? Style { get; set; }

    }
}
