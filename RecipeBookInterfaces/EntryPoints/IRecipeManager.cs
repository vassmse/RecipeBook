using RecipeBookInterfaces.Models;
using RecipeBookInterfaces.Models.Tables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace RecipeBookInterfaces.EntryPoints
{
    public interface IRecipeManager
    {
        ObservableCollection<Recipe> GetRecipes();

        List<RecipeType> GetRecipeTypes();

        List<RawMaterial> GetRawMaterial();

        List<string> GetUnits();

        void AddRecipe(Recipe recipe);

        void DeleteRecipe(Recipe recipe);

        void ModifyRecipe(Recipe recipe);
    }
}
