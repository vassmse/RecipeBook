using RecipeBookInterfaces.EntryPoints;
using RecipeBookInterfaces.Models;
using RecipeBookInterfaces.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Models
{
    public class MyRecipeBook : IMyRecipeBook
    {
        public List<Recipe> Recipes { get; set; }

        public IRecipeManager BusinessLayer { get; set; }

        public MyRecipeBook(IRecipeManager businessLayer)
        {
            this.BusinessLayer = businessLayer;
            Recipes = this.BusinessLayer.GetRecipes();            
        }

        public void AddRecipe(Recipe recipe)
        {
            if (!Recipes.Contains(recipe))
            {
                Recipes.Add(recipe);
                BusinessLayer.AddRecipe(recipe);
            }
        }

        public void DeleteRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public void ModifyRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}
