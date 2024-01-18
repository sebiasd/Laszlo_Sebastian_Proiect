using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Laszlo_Sebastian_Proiect.Data;
using Laszlo_Sebastian_Proiect.Models;

namespace Laszlo_Sebastian_Proiect.Pages.Tattoos
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
                return Page();
            }
        


        [BindProperty]
        public Tattoo Tattoo { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Tattoo == null || Tattoo == null)
            {
                return Page();
            }

            _context.Tattoo.Add(Tattoo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
