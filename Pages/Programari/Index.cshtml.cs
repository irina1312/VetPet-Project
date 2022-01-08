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
    public class IndexModel : PageModel
    {
        private readonly VetPet.Data.VetPetContext _context;

        public IndexModel(VetPet.Data.VetPetContext context)
        {
            _context = context;
        }

        public IList<Programare> Programare { get;set; }

        public async Task OnGetAsync()
        {
            Programare = await _context.Programare.ToListAsync();
        }
    }
}
