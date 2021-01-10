using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Momeu_Olivia_Proiect.Data;
using Momeu_Olivia_Proiect.Models;

namespace Momeu_Olivia_Proiect.Pages.Furnizori
{
    public class IndexModel : PageModel
    {
        private readonly Momeu_Olivia_Proiect.Data.Momeu_Olivia_ProiectContext _context;

        public IndexModel(Momeu_Olivia_Proiect.Data.Momeu_Olivia_ProiectContext context)
        {
            _context = context;
        }

        public IList<Furnizor> Furnizor { get;set; }

        public async Task OnGetAsync()
        {
            Furnizor = await _context.Furnizor.ToListAsync();
        }
    }
}
