using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookInterfaces.Models
{
    public interface IMyRecipeBook
    {
        void Add(Recipe recipe);

        void Delete(Recipe recipe);
    }
}
