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
        const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Database=RecipeDb;Initial Catalog=master;Integrated Security=True;Connect Timeout=130;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public RecipeManager()
        {           

        }

        public List<Recipe> GetRecipes()
        {
            //TODO: get recipes from DB
            var flour = new Ingredient { Quantity = 0.5, Unit = IngredientUnit.kg };                        
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
            //try
            //{
            //    var builder = new DbContextOptionsBuilder<RecipeBookContext>();
            //    builder.UseSqlServer(ConnectionString);

            //    using (var dbContext = new RecipeBookContext(builder.Options))
            //    {
            //        dbContext.Recipes.Attach(recipe);
            //        dbContext.SaveChanges();
                    
            //        foreach (var rec in dbContext.Recipes)
            //        {
            //            Console.WriteLine(rec.Name);
            //        }
            //    }
            //}

            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    throw;
            //}
        }

        public void DeleteRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public void ModifyRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}
