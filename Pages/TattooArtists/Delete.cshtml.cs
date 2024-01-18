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
    public class DeleteModel : PageModel
    {
        private readonly Laszlo_Sebastian_Proiect.Data.Laszlo_Sebastian_ProiectContext _context;

        public DeleteModel(Laszlo_Sebastian_Proiect.Data.Laszlo_Sebastian_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TattooArtist == null)
            {
                return NotFound();
            }
            var tattooartist = await _context.TattooArtist.FindAsync(id);

            if (tattooartist != null)
            {
                TattooArtist = tattooartist;
                _context.TattooArtist.Remove(TattooArtist);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
