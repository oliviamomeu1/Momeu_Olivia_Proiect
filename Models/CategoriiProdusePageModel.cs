using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Momeu_Olivia_Proiect.Data;

namespace Momeu_Olivia_Proiect.Models
{
    public class CategoriiProdusePageModel : PageModel 
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Momeu_Olivia_ProiectContext context, Produs produs)
        {
            var allCategories = context.Categorie;
            var categoriiProduse = new HashSet<int>(
            produs.CategoriiProduse.Select(c => c.ProdusID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategorieID = cat.ID,
                    Nume = cat.NumeCategorie,
                    Assigned = categoriiProduse.Contains(cat.ID)
                });
            }
        }
        public void UpdateCategoriiProduse(Momeu_Olivia_ProiectContext context, string[] selectedCategories, Produs produsToUpdate)
        {
            if (selectedCategories == null)
            {
                produsToUpdate.CategoriiProduse = new List<CategorieProdus>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var categoriiProduse = new HashSet<int>
            (produsToUpdate.CategoriiProduse.Select(c => c.Categorie.ID));
            foreach (var cat in context.Categorie)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!categoriiProduse.Contains(cat.ID))
                    {
                        produsToUpdate.CategoriiProduse.Add(
                        new CategorieProdus
                        {
                            ProdusID = produsToUpdate.ID,
                            CategorieID = cat.ID
                        });
                    }
                }
                else
                {
                    if (categoriiProduse.Contains(cat.ID))
                    {
                        CategorieProdus courseToRemove
                        = produsToUpdate
                        .CategoriiProduse
                        .SingleOrDefault(i => i.CategorieID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
