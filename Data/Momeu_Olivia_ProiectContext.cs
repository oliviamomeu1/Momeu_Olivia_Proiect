using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Momeu_Olivia_Proiect.Models;

namespace Momeu_Olivia_Proiect.Data
{
    public class Momeu_Olivia_ProiectContext : DbContext
    {
        public Momeu_Olivia_ProiectContext (DbContextOptions<Momeu_Olivia_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Momeu_Olivia_Proiect.Models.Produs> Produs { get; set; }

        public DbSet<Momeu_Olivia_Proiect.Models.Furnizor> Furnizor { get; set; }

        public DbSet<Momeu_Olivia_Proiect.Models.Categorie> Categorie { get; set; }

        public DbSet<Momeu_Olivia_Proiect.Models.CategorieProdus> CategorieProdus { get; set; }
    }
}
