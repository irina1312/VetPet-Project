using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VetPet.Data;
using VetPet.Models;

namespace VetPet.Pages.Reviews
{
    public class DetailsModel : PageModel
    {
        private readonly VetPet.Data.VetPetContext _context;

        public DetailsModel(VetPet.Data.VetPetContext context)
        {
            _context = context;
        }

        public Review Review { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Review = await _context.Review.FirstOrDefaultAsync(m => m.ID == id);

            if (Review == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
