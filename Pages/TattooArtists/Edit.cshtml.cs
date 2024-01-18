using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Laszlo_Sebastian_Proiect.Data;
using Laszlo_Sebastian_Proiect.Models;

namespace Laszlo_Sebastian_Proiect.Pages.TattooArtists
{
    public class EditModel : PageModel
    {
        private readonly Laszlo_Sebastian_Proiect.Data.Laszlo_Sebastian_ProiectContext _context;

        public EditModel(Laszlo_Sebastian_Proiect.Data.Laszlo_Sebastian_ProiectContext context)
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

            var tattooartist =  await _context.TattooArtist.FirstOrDefaultAsync(m => m.ID == id);
            if (tattooartist == null)
            {
                return NotFound();
            }
            TattooArtist = tattooartist;
           ViewData["LocationID"] = new SelectList(_context.Location, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TattooArtist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TattooArtistExists(TattooArtist.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TattooArtistExists(int id)
        {
          return (_context.TattooArtist?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
