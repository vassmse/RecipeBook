using RecipeBook.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Models
{
    public class RecipeBook
    {
        public List<Recipe> Recipes { get; set; }

        public RecipeBook(String databaseName)
        {
            Recipes = BusinessLayer.GetRecipes();
        }

        public void Add(Recipe recipe)
        {
            if (!Recipes.Contains(recipe))
            {
                Recipes.Add(recipe);
                BusinessLayer.Write(recipe);
            }
        }

        public void Delete(Recipe recipe)
        {
            if (Recipes.Contains(recipe))
            {
                Recipes.Remove(recipe);
                BusinessLayer.Delete(recipe);
            }
        }

        public void Update(Recipe recipe)
        {
            BusinessLayer.Write(recipe);
        }
    }
}