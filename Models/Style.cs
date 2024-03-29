﻿using System.ComponentModel.DataAnnotations;

namespace Laszlo_Sebastian_Proiect.Models
{
    public class Style
    {
        public int ID { get; set; }

        [Display(Name = "Style")]
        [RegularExpression("^[A-Z][a-z]*$", ErrorMessage = "Style must start with an uppercase letter.")]
        public string StyleName { get; set; }

        public string Description { get; set; }

        public ICollection<Tattoo>? Tattoos { get; set; }
        public ICollection<TattooArtist>? TattooArtists { get; set; }


    }
}
