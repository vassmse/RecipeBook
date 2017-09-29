using RecipeBookInterfaces.EntryPoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeBookInterfaces.Models;

namespace RecipeBookBLL.EntryPoints
{
    public class RecipeManager : IRecipeManager
    {
        private RecipeManager()
        {
            //TODO: db init stb
        }


        public List<Recipe> GetRecipes()
        {
            //TODO: get recipes from DB
            var flour = new Ingredient { Name = "liszt", Quantity = 0.5, Unit = IngredientUnit.kg };
            var water = new Ingredient { Name = "víz", Quantity = 0.2, Unit = IngredientUnit.liter };
            var ingredients = new List<Ingredient>
            {
                flour,
                water
            };

            return new List<Recipe>()
                {
                    new Recipe { Name="Borsóleves", Description="Meg kell főzni", Ingredients=ingredients},
                    new Recipe { Name="Lasagna", Description="Meg kell sütni", Ingredients=ingredients},
                    new Recipe { Name="Pizza" , Description="Meg kell sütni", Ingredients=ingredients}
                };
        }

        public void AddRecipe(Recipe recipe)
        {
            //TODO: insert recipe to DB
        }

        public void DeleteRecipe(Recipe recipe)
        {
            //TODO: delete recipe from DB
        }
    }
}
