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
    public class EditModel : CategoriiProdusePageModel
    {
        private readonly Momeu_Olivia_Proiect.Data.Momeu_Olivia_ProiectContext _context;

        public EditModel(Momeu_Olivia_Proiect.Data.Momeu_Olivia_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
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

            //Produs = await _context.Produs.FirstOrDefaultAsync(m => m.ID == id);

            if (Produs == null)
            {
                return NotFound();
            }
            //apelam PopulateAssignedCategoryData pentru o obtine informatiile necesare checkbox-
            //urilor folosind clasa AssignedCategoryData
            PopulateAssignedCategoryData(_context, Produs);

            ViewData["FurnizorID"] = new SelectList(_context.Set<Furnizor>(), "ID", "NumeFurnizor");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var produsToUpdate = await _context.Produs
            .Include(i => i.Furnizor)
            .Include(i => i.CategoriiProduse)
            .ThenInclude(i => i.Categorie)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (produsToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Produs>(produsToUpdate, "Produs",
            i => i.Denumire, i => i.Producator,
            i => i.Pret, i => i.DataDisponibilitatii, i => i.Furnizor))
            {
                UpdateCategoriiProduse(_context, selectedCategories, produsToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateCategoriiProduse(_context, selectedCategories, produsToUpdate);
            PopulateAssignedCategoryData(_context, produsToUpdate);
            return Page();
        }

        private bool ProdusExists(int id)
        {
            return _context.Produs.Any(e => e.ID == id);
        }
    }
}
