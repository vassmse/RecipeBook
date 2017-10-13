using RecipeBookInterfaces.EntryPoints;
using RecipeBookInterfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeBookBLL.Models
{
    public class RecipeManager : IRecipeManager
    {
        #region Singleton

        //private static readonly RecipeManager instance = new RecipeManager();

        //private RecipeManager() { }

        //public static RecipeManager Instance
        //{
        //    get
        //    {
        //        return instance;
        //    }
        //}

        #endregion


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