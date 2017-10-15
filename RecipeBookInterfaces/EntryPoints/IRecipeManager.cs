using RecipeBookInterfaces.Models;
using RecipeBookInterfaces.Models.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeBookInterfaces.EntryPoints
{
    public interface IRecipeManager
    {
        List<Recipe> GetRecipes();

        void AddRecipe(Recipe recipe);

        void DeleteRecipe(Recipe recipe);
    }
}
