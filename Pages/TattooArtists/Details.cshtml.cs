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
    public class DetailsModel : PageModel
    {
        private readonly Laszlo_Sebastian_Proiect.Data.Laszlo_Sebastian_ProiectContext _context;

        public DetailsModel(Laszlo_Sebastian_Proiect.Data.Laszlo_Sebastian_ProiectContext context)
        {
            _context = context;
        }

      public TattooArtist TattooArtist { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TattooArtist == null)
            {
                return NotFound();
            }

            var tattooartist = await _context.TattooArtist.FirstOrDefaultAsync(m => m.ID == id);
            if (tattooartist == null)
            {
                return NotFound();
            }
            else 
            {
                TattooArtist = tattooartist;
            }
            return Page();
        }
    }
}
