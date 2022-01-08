using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VetPet.Data;
using VetPet.Models;

namespace VetPet.Pages.Programari
{
    public class EditModel : ReviewsPageModel
    {
        private readonly VetPet.Data.VetPetContext _context;

        public EditModel(VetPet.Data.VetPetContext context)
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

            Programare = await _context.Programare
                .Include(b => b.MedicReviews)
                .ThenInclude(b => b.Review)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Programare == null)
            {
                return NotFound();
            }
            PopulateStea(_context, Programare);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedReviews)
        
            {
                if (id == null)
                {
                    return NotFound();
                }
                var programareToUpdate = await _context.Programare
                .Include(i => i.MedicReviews)
                .ThenInclude(i => i.Review)
                .FirstOrDefaultAsync(s => s.ID == id);
                if (programareToUpdate == null)
                {
                    return NotFound();
                }
                if (await TryUpdateModelAsync<Programare>(
                programareToUpdate,
                "Programare",
                i => i.Nume_pacient, i => i.Nume_insotitor,
                i => i.Nume_doctor, i => i.Data_programarii))
                {
                    UpdateMedicReviews(_context, selectedReviews, programareToUpdate);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
                //este editata
                UpdateMedicReviews(_context, selectedReviews, programareToUpdate);
                PopulateStea(_context, programareToUpdate);
                return Page();
            }
        }
    }
