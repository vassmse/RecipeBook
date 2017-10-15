using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RecipeBookInterfaces.EntryPoints;
using RecipeBookInterfaces.Models;
using RecipeBookInterfaces.Models.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeBookBLL.Models
{
    public class RecipeManager : IRecipeManager
    {
        public RecipeManager()
        {           

        }

        public List<Recipe> GetRecipes()
        {
            //TODO: get recipes from DB
            var flour = new Ingredient { Quantity = 0.5, Unit = IngredientUnit.kg };

            try
            {
                var builder = new DbContextOptionsBuilder<RecipeBookContext>();

                builder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RecipeDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");


                using (var dbContext = new RecipeBookContext(builder.Options))
                {
                    dbContext.Ingredients.Attach(flour);
                    dbContext.SaveChanges();

                    //var query = from b in dbContext.Ingredients
                    //            orderby b.
                    //            select b;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            var water = new Ingredient { Id = 1, Quantity = 0.2, Unit = IngredientUnit.liter };

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
