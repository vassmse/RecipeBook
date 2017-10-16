using RecipeBookInterfaces.Models.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeBookInterfaces.Models
{
    public interface IMyRecipeBook
    {
        void AddRecipe(Recipe recipe);

        void DeleteRecipe(Recipe recipe);

        void ModifyRecipe(Recipe recipe);
    }
}
