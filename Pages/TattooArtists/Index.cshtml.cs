using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Laszlo_Sebastian_Proiect.Data;
using Laszlo_Sebastian_Proiect.Models;

namespace Laszlo_Sebastian_Proiect.Pages.TattooArtists
{
    public class IndexModel : PageModel
    {
        private readonly Laszlo_Sebastian_Proiect.Data.Laszlo_Sebastian_ProiectContext _context;

        public IndexModel(Laszlo_Sebastian_Proiect.Data.Laszlo_Sebastian_ProiectContext context)
        {
            _context = context;
        }

        public IList<TattooArtist> TattooArtist { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TattooArtist != null)
            {
                TattooArtist = await _context.TattooArtist
                .Include(t => t.Location)
                .Include(t => t.Style)

                .ToListAsync();
                
            }
        }
    }
}
