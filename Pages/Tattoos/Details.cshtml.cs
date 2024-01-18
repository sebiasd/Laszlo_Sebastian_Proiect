using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Laszlo_Sebastian_Proiect.Data;
using Laszlo_Sebastian_Proiect.Models;

namespace Laszlo_Sebastian_Proiect.Pages.Tattoos
{
    public class DetailsModel : PageModel
    {
        private readonly Laszlo_Sebastian_Proiect.Data.Laszlo_Sebastian_ProiectContext _context;

        public DetailsModel(Laszlo_Sebastian_Proiect.Data.Laszlo_Sebastian_ProiectContext context)
        {
            _context = context;
        }

      public Tattoo Tattoo { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tattoo == null)
            {
                return NotFound();
            }

            var tattoo = await _context.Tattoo.FirstOrDefaultAsync(m => m.Id == id);
            if (tattoo == null)
            {
                return NotFound();
            }
            else 
            {
                Tattoo = tattoo;
            }
            return Page();
        }
    }
}
