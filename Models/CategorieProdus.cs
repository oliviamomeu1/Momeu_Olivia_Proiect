using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Momeu_Olivia_Proiect.Models
{
    public class CategorieProdus
    {
        public int ID { get; set; }
        public int ProdusID { get; set; }
        public Produs Produs { get; set; }
        public int CategorieID { get; set; }

        [Display(Name = "Categorie")]
        public Categorie Categorie { get; set; }
    }
}
