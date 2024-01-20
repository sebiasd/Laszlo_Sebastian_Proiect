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
        public IList<string> TattooArtists { get; set; } = new List<string>();
        [BindProperty(SupportsGet = true)]
        public string? SearchClient { get; set; }

        public async Task OnGetAsync(string? searchTattooArtist)
        {
            IQueryable<Tattoo> tattooQuery = _context.Tattoo
                .Include(r => r.Location)
                .Include(r => r.TattooArtist)
                .Include(r => r.Style);

            if (!string.IsNullOrEmpty(SearchClient))
            {
                tattooQuery = tattooQuery.Where(t => t.ClientName.Contains(SearchClient));
            }

            if (!string.IsNullOrEmpty(searchTattooArtist))
            {
                tattooQuery = tattooQuery.Where(t => t.TattooArtist.ArtistName == searchTattooArtist);
            }

            Tattoo = await tattooQuery.ToListAsync();

            TattooArtists = await _context.Tattoo.Select(t => t.TattooArtist.ArtistName).Distinct().ToListAsync();
        }
    }
}
