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
            var flour = new Ingredient { Quantity = 0.5, Unit = "kg" };                        
            var water = new Ingredient { Id = 1, Quantity = 0.2, Unit = "liter" };

            var ingredients = new List<Ingredient>
            {
                flour,
                water
            };

            try
            {
                using (var db = new RecipeBookContext())
                {
                    var tmp = db.RawMaterialType;

                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return new List<Recipe>()
                {
                    new Recipe { Name="Borsóleves", Description="Meg kell főzni", PreparationTime=20, Ingredients=ingredients},
                    new Recipe { Name="Lasagna", Description="Meg kell sütni", PreparationTime=140, Ingredients=ingredients},
                    new Recipe { Name="Pizza" , Description="Meg kell sütni", PreparationTime=180, Ingredients=ingredients}
                };
        }

        public void AddRecipe(Recipe recipe)
        {
            //try
            //{
            //    using (var db = new RecipeBookContext())
            //    {
            //        var recipe = new Rec { Url = "http://sample.com" };
            //        db.Blogs.Add(blog);
            //        db.SaveChanges();
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
