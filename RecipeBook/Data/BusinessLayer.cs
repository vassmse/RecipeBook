using RecipeBook.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Data
{
    public class BusinessLayer
    {
        private static BusinessLayer _instance = null;

        public static BusinessLayer Instance()
        {
            if (_instance == null)
            {
                _instance = new BusinessLayer();
            }

            return _instance;
        }

        private BusinessLayer()
        {
            //TODO: db init stb
        }


        public static List<Recipe> GetRecipes()
        {
            //TODO: get recipes from DB
            var flour = new Ingredient { Name = "liszt", Quantity = 0.5, Unit = "kg" };
            var water = new Ingredient { Name = "víz", Quantity = 0.2, Unit = "l" };
            var ingredients = new List<Ingredient>();
            ingredients.Add(flour);
            ingredients.Add(water);

            return new List<Recipe>()
                {
                    new Recipe { Name="Borsóleves", Description="Meg kell főzni", Ingredients=ingredients},
                    new Recipe { Name="Lasagna", Description="Meg kell sütni", Ingredients=ingredients},
                    new Recipe { Name="Pizza" , Description="Meg kell sütni", Ingredients=ingredients}
                };
        }

        public static void AddRecipe(Recipe recipe)
        {
            //TODO: insert recipe to DB
        }

        public static void DeleteRecipe(Recipe recipe)
        {
            //TODO: delete recipe from DB
        }

    }
}
