using RecipeBookInterfaces.EntryPoints;
using RecipeBookInterfaces.Models;
using RecipeBookInterfaces.Models.Tables;
using System;
using System.Collections.Generic;

namespace RecipeBook.Models
{
    public class MyRecipeBook : IMyRecipeBook
    {
        public List<Recipe> Recipes { get; set; }
                
        public IRecipeManager BusinessLayer { get; set; }
        
        public List<Recipe> Soups
        {
            get { return Recipes.FindAll(r => r.Type.Name == "Leves"); }
        }

        public List<Recipe> MainCourses
        {
            get { return Recipes.FindAll(r => r.Type.Name == "Főétel"); }
        }


        public MyRecipeBook(IRecipeManager businessLayer)
        {
            BusinessLayer = businessLayer;
            Recipes = BusinessLayer.GetRecipes();
        }

        #region BL methods

        public void AddRecipe(Recipe recipe)
        {
            if (!Recipes.Contains(recipe))
            {
                Recipes.Add(recipe);
                BusinessLayer.AddRecipe(recipe);
            }
        }

        public void DeleteRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public void ModifyRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
