using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Momeu_Olivia_Proiect.Models
{
    public class ProdusData
    {
        public IEnumerable<Produs> Produse { get; set; }
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<CategorieProdus> CategoriiProduse { get; set; }
    }
}
