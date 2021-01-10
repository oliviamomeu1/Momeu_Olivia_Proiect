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

namespace Momeu_Olivia_Proiect.Pages.Furnizori
{
    public class EditModel : PageModel
    {
        private readonly Momeu_Olivia_Proiect.Data.Momeu_Olivia_ProiectContext _context;

        public EditModel(Momeu_Olivia_Proiect.Data.Momeu_Olivia_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Furnizor Furnizor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Furnizor = await _context.Furnizor.FirstOrDefaultAsync(m => m.ID == id);

            if (Furnizor == null)
            {
                return NotFound();
            }
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

            _context.Attach(Furnizor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FurnizorExists(Furnizor.ID))
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

        private bool FurnizorExists(int id)
        {
            return _context.Furnizor.Any(e => e.ID == id);
        }
    }
}
