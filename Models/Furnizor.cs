using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Momeu_Olivia_Proiect.Models
{
    public class Furnizor
    {
        public int ID { get; set; }

        [Display(Name = "Furnizor")]
        public string NumeFurnizor { get; set; }
        public ICollection<Produs> Produse { get; set; } //navigation property
    }
}
