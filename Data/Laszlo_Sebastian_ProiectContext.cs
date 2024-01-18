using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Laszlo_Sebastian_Proiect.Models;

namespace Laszlo_Sebastian_Proiect.Data
{
    public class Laszlo_Sebastian_ProiectContext : DbContext
    {
        public Laszlo_Sebastian_ProiectContext (DbContextOptions<Laszlo_Sebastian_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Laszlo_Sebastian_Proiect.Models.Tattoo> Tattoo { get; set; } = default!;

        public DbSet<Laszlo_Sebastian_Proiect.Models.Location>? Location { get; set; }

        public DbSet<Laszlo_Sebastian_Proiect.Models.TattooArtist>? TattooArtist { get; set; }

        public DbSet<Laszlo_Sebastian_Proiect.Models.Style>? Style { get; set; }
    }
}
