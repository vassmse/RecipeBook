using RecipeBookInterfaces.Models.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeBookInterfaces.Models
{
    public interface IMyRecipeBook
    {
        void Add(Recipe recipe);

        void Delete(Recipe recipe);

        void Modify(Recipe recipe);
    }
}
