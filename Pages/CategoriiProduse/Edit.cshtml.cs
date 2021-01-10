using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Momeu_Olivia_Proiect.Data;
using Momeu_Olivia_Proiect.Models;

namespace Momeu_Olivia_Proiect.Pages.CategoriiProduse
{
    public class EditModel : PageModel
    {
        private readonly Momeu_Olivia_Proiect.Data.Momeu_Olivia_ProiectContext _context;

        public EditModel(Momeu_Olivia_Proiect.Data.Momeu_Olivia_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CategorieProdus CategorieProdus { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CategorieProdus = await _context.CategorieProdus
                .Include(c => c.Categorie)
                .Include(c => c.Produs).FirstOrDefaultAsync(m => m.ID == id);

            if (CategorieProdus == null)
            {
                return NotFound();
            }
           ViewData["CategorieID"] = new SelectList(_context.Categorie, "ID", "NumeCategorie");
           ViewData["ProdusID"] = new SelectList(_context.Produs, "ID", "ProdusProducator");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CategorieProdus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieProdusExists(CategorieProdus.ID))
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

        private bool CategorieProdusExists(int id)
        {
            return _context.CategorieProdus.Any(e => e.ID == id);
        }
    }
}
