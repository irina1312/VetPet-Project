using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VetPet.Data;
using VetPet.Models;

namespace VetPet.Pages.Programari
{
    public class DeleteModel : PageModel
    {
        private readonly VetPet.Data.VetPetContext _context;

        public DeleteModel(VetPet.Data.VetPetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Programare Programare { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Programare = await _context.Programare.FirstOrDefaultAsync(m => m.ID == id);

            if (Programare == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Programare = await _context.Programare.FindAsync(id);

            if (Programare != null)
            {
                _context.Programare.Remove(Programare);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
