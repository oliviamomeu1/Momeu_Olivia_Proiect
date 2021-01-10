using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Momeu_Olivia_Proiect.Models
{
    public class Categorie
    {
        public int ID { get; set; }

        [Display(Name = "Categorie")]
        public string NumeCategorie { get; set; }
        public ICollection<CategorieProdus> CategoriiProduse { get; set; }
    }
}
