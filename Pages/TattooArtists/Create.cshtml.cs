using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Laszlo_Sebastian_Proiect.Data;
using Laszlo_Sebastian_Proiect.Models;

namespace Laszlo_Sebastian_Proiect.Pages.TattooArtists
{
    public class CreateModel : PageModel
    {
        private readonly Laszlo_Sebastian_Proiect.Data.Laszlo_Sebastian_ProiectContext _context;

        public CreateModel(Laszlo_Sebastian_Proiect.Data.Laszlo_Sebastian_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["LocationID"] = new SelectList(_context.Set<Location>(), "ID", "LocationName");

            ViewData["StyleID"] = new SelectList(_context.Set<Style>(), "ID", "StyleName");
            
            return Page();


        }

        [BindProperty]
        public TattooArtist TattooArtist { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.TattooArtist == null || TattooArtist == null)
            {
                return Page();
            }

            _context.TattooArtist.Add(TattooArtist);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
