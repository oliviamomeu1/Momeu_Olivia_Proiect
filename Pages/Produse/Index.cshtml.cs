using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Momeu_Olivia_Proiect.Data;
using Momeu_Olivia_Proiect.Models;

namespace Momeu_Olivia_Proiect.Pages.Produse
{
    public class IndexModel : PageModel
    {
        private readonly Momeu_Olivia_Proiect.Data.Momeu_Olivia_ProiectContext _context;

        public IndexModel(Momeu_Olivia_Proiect.Data.Momeu_Olivia_ProiectContext context)
        {
            _context = context;
        }

        public IList<Produs> Produs { get;set; }
        public ProdusData ProdusD { get; set; }
        public int ProdusID { get; set; }
        public int CategorieID { get; set; }
        public async Task OnGetAsync(int? id, int? categorieID)
        {
            ProdusD = new ProdusData();

            ProdusD.Produse = await _context.Produs
            .Include(b => b.Furnizor)
            .Include(b => b.CategoriiProduse)
            .ThenInclude(b => b.Categorie)
            .AsNoTracking()
            .OrderBy(b => b.Denumire)
            .ToListAsync();
            if (id != null)
            {
                ProdusID = id.Value;
                Produs produs = ProdusD.Produse
                .Where(i => i.ID == id.Value).Single();
                ProdusD.Categorii = produs.CategoriiProduse.Select(s => s.Categorie);
            }
        }
    }
}
