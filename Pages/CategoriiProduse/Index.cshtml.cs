using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Momeu_Olivia_Proiect.Data;
using Momeu_Olivia_Proiect.Models;

namespace Momeu_Olivia_Proiect.Pages.CategoriiProduse
{
    public class IndexModel : PageModel
    {
        private readonly Momeu_Olivia_Proiect.Data.Momeu_Olivia_ProiectContext _context;

        public IndexModel(Momeu_Olivia_Proiect.Data.Momeu_Olivia_ProiectContext context)
        {
            _context = context;
        }

        public IList<CategorieProdus> CategorieProdus { get;set; }

        public async Task OnGetAsync()
        {
            CategorieProdus = await _context.CategorieProdus
                .Include(c => c.Categorie)
                .Include(c => c.Produs).ToListAsync();
        }
    }
}
