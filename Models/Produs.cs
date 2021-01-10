using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Momeu_Olivia_Proiect.Models
{
    public class Produs
    {
        public int ID { get; set; }

        [Required, StringLength(50, MinimumLength = 3, ErrorMessage="Minim 3 caractere, maxim 50 !")]
        [Display(Name = "Denumire produs")]
        public string Denumire { get; set; }

        //^ marcheaza inceputul sirului de caractere
        //[A-Z][a-z]+  -litera mare urmata de oricate litere mici
        //\s* 0 sau mai multe spatii
        //[A-Z]*[a-z]+* - 0 sau > litera mare urmata de 0 sau > litere mici
        [RegularExpression(@"^[A-Z][a-z]+\s*[A-Z]*[a-z]*", ErrorMessage = "Numele producatorului trebuie sa contina 1 sau maxim 2 cuvinte incepand cu litera mare. "), Required, StringLength(50, MinimumLength = 3)]
        public string Producator { get; set; }

        [Range(1, 1000, ErrorMessage ="Pretul trebuie sa fie intre 1 si 1000 lei!")]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }

        [Display(Name = "Data disponibilitatii")]
        [DataType(DataType.Date)]
        public DateTime DataDisponibilitatii { get; set; }

        public int FurnizorID { get; set; }

        public Furnizor Furnizor { get; set; } //navigation property

        [Display(Name = "Categorie")]
        public ICollection<CategorieProdus> CategoriiProduse { get; set; }
        public string ProdusProducator { get { return Denumire + " by " + Producator; } }
    }
}
