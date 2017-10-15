using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RecipeBookInterfaces.EntryPoints;
using RecipeBookInterfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeBookBLL.Models
{
    public class RecipeManager : IRecipeManager
    {
        // RecipeContext DbContext = new RecipeContext();

        public RecipeManager()
        {
            

        }

        public List<Recipe> GetRecipes()
        {
            //TODO: get recipes from DB
            //var flour = new Ingredient { Name = "liszt", Quantity = 0.5, Unit = IngredientUnit.kg };
            var flour = new Ingredient { Name = "liszt", Quantity = 0.5 };

            try
            {
                var builder = new DbContextOptionsBuilder<RecipeBookContext>();
                builder.UseSqlServer(
                    "Server=(localdb)\\mssqllocaldb;Database=config;Trusted_Connection=True;MultipleActiveResultSets=true");
                
                using (var dbContext = new RecipeBookContext(builder.Options))
                {
                    dbContext.Ingredients.Add(flour);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            //var water = new Ingredient { Name = "víz", Quantity = 0.2, Unit = IngredientUnit.liter };
            var water = new Ingredient { Name = "víz", Quantity = 0.2 };
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
            //TODO
        }

        public void DeleteRecipe(Recipe recipe)
        {
            //TODO: delete recipe from DB
        }
    }
}
