using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Momeu_Olivia_Proiect.Data;
using Momeu_Olivia_Proiect.Models;

namespace Momeu_Olivia_Proiect.Pages.CategoriiProduse
{
    public class CreateModel : PageModel
    {
        private readonly Momeu_Olivia_Proiect.Data.Momeu_Olivia_ProiectContext _context;

        public CreateModel(Momeu_Olivia_Proiect.Data.Momeu_Olivia_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategorieID"] = new SelectList(_context.Categorie, "ID", "NumeCategorie");
        ViewData["ProdusID"] = new SelectList(_context.Produs, "ID", "ProdusProducator");
            return Page();
        }

        [BindProperty]
        public CategorieProdus CategorieProdus { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CategorieProdus.Add(CategorieProdus);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
