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

        public List<RecipeType> RecipeTypes { get; set; }

        public List<RawMaterial> RawMaterials { get; set; }

        public List<string> Units { get; set; }

        public IRecipeManager BusinessLayer { get; set; }
        
        public List<Recipe> Soups { get; set; }


        public List<Recipe> MainCourses { get; set; }



        public MyRecipeBook(IRecipeManager businessLayer)
        {
            BusinessLayer = businessLayer;
            Recipes = BusinessLayer.GetRecipes();
            RecipeTypes = BusinessLayer.GetRecipeTypes();
            RawMaterials = BusinessLayer.GetRawMaterial();
            Units = BusinessLayer.GetUnits();
            Soups = Recipes.FindAll(r => r.Type.Name == "Leves");
            MainCourses = Recipes.FindAll(r => r.Type.Name == "Főétel");
        }

        #region BL methods

        public void AddRecipe(Recipe recipe)
        {
            if (!Recipes.Contains(recipe))
            {
                Recipes.Add(recipe);
                BusinessLayer.AddRecipe(recipe);
                MainCourses = Recipes.FindAll(r => r.Type.Name == "Főétel");
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
