using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Momeu_Olivia_Proiect.Data;
using Momeu_Olivia_Proiect.Models;

namespace Momeu_Olivia_Proiect.Pages.Produse
{
    public class CreateModel : CategoriiProdusePageModel
    {
        private readonly Momeu_Olivia_Proiect.Data.Momeu_Olivia_ProiectContext _context;

        public CreateModel(Momeu_Olivia_Proiect.Data.Momeu_Olivia_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["FurnizorID"] = new SelectList(_context.Set<Furnizor>(), "ID", "NumeFurnizor");
            var produs = new Produs();
            produs.CategoriiProduse = new List<CategorieProdus>();
            PopulateAssignedCategoryData(_context, produs);
            return Page();
        }

        [BindProperty]
        public Produs Produs { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newProdus = new Produs();
            if (selectedCategories != null)
            {
                newProdus.CategoriiProduse = new List<CategorieProdus>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new CategorieProdus
                    {
                        CategorieID = int.Parse(cat)
                    };
                    newProdus.CategoriiProduse.Add(catToAdd);
                }
            }

            if (await TryUpdateModelAsync<Produs>(
            newProdus,
            "Produs",
            i => i.Denumire, i => i.Producator,
            i => i.Pret, i => i.DataDisponibilitatii, i => i.FurnizorID))
            {
                _context.Produs.Add(newProdus);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newProdus);
            return Page();
        }
    }
}
