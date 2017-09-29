using RecipeBookInterfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookInterfaces.EntryPoints
{
    public interface IRecipeManager
    {
        List<Recipe> GetRecipes();

        void AddRecipe(Recipe recipe);

        void DeleteRecipe(Recipe recipe);
    }
}
