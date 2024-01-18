using System.ComponentModel.DataAnnotations;

namespace Laszlo_Sebastian_Proiect.Models
{
    public class TattooArtist
    {
        public int ID { get; set; }

        [Display(Name = "Name")]
        public string ArtistName { get; set; }

        public string Description { get; set; }

        [Display(Name = "Location")]

        public int? LocationID { get; set; }

        public Location? Location { get; set; }

        public int? StyleID { get; set; }

        public Style? Style { get; set; }

        public ICollection<Tattoo>? Tattoos { get; set; }
    }
}

