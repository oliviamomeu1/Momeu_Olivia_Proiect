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

namespace Momeu_Olivia_Proiect.Pages.Produse
{
    public class DetailsModel : CategoriiProdusePageModel
    {
        private readonly Momeu_Olivia_Proiect.Data.Momeu_Olivia_ProiectContext _context;

        public DetailsModel(Momeu_Olivia_Proiect.Data.Momeu_Olivia_ProiectContext context)
        {
            _context = context;
        }

        public Produs Produs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Produs = await _context.Produs
               .Include(b => b.Furnizor)
               .Include(b => b.CategoriiProduse).ThenInclude(b => b.Categorie)
               .AsNoTracking()
               .FirstOrDefaultAsync(m => m.ID == id);


            if (Produs == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Produs);

            ViewData["FurnizorID"] = new SelectList(_context.Set<Furnizor>(), "ID", "NumeFurnizor");
            return Page();
        }
    }
}
