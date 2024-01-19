using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Laszlo_Sebastian_Proiect.Data;
using Laszlo_Sebastian_Proiect.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laszlo_Sebastian_Proiect.Pages.Tattoos
{
    public class IndexModel : PageModel
    {
        private readonly Laszlo_Sebastian_Proiect.Data.Laszlo_Sebastian_ProiectContext _context;

        public IndexModel(Laszlo_Sebastian_Proiect.Data.Laszlo_Sebastian_ProiectContext context)
        {
            _context = context;
        }

        public IList<Tattoo> Tattoo { get; set; } = default!;
        public IList<string> UniqueArtists { get; set; } = new List<string>();
        public IList<Tattoo> FilteredTattoos { get; set; } = new List<Tattoo>();

        [BindProperty(SupportsGet = true)]
        public string SelectedArtist { get; set; } = "";

        public async Task OnGetAsync()
        {
            if (_context.Tattoo != null)
            {
                Tattoo = await _context.Tattoo
                    .Include(r => r.Location)
                    .Include(r => r.TattooArtist)
                    .Include(r => r.Style)
                    .ToListAsync();

                // Populate UniqueArtists for dropdown
                UniqueArtists = Tattoo.Select(t => t.TattooArtist.ArtistName).Distinct().ToList();

                // Apply filtering based on the selected artist
                FilteredTattoos = string.IsNullOrEmpty(SelectedArtist)
                    ? Tattoo.ToList()
                    : Tattoo.Where(t => t.TattooArtist.ArtistName == SelectedArtist).ToList();
            }
        }
    }
}
