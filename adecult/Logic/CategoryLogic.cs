using System.Collections.Generic;
using System.Linq;
using adecult.entities;
using adecult.Models;

namespace adecult.Logic
{
    public class CategoryLogic
    {
        public List<Category> GetCategorias()
        {
            var db = new adecultContext();
            List<Category> categoryList = new List<Category>();
            foreach (Categorias cat in db.Categorias.ToList())
            {
                categoryList.Add(new Category
                {
                    Id = cat.Id,
                    Name = cat.Name,
                    CatPadre = cat.CatPadre
                });
            }
            return categoryList;
        }
    }
}
