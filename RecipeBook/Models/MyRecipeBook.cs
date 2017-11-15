using RecipeBookInterfaces.EntryPoints;
using RecipeBookInterfaces.Models;
using RecipeBookInterfaces.Models.Tables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RecipeBook.Models
{
    public class MyRecipeBook : IMyRecipeBook
    {
        public List<Recipe> Recipes { get; set; }

        public List<RecipeType> RecipeTypes { get; set; }

        public List<RawMaterial> RawMaterials { get; set; }

        public List<string> Units { get; set; }

        public IRecipeManager BusinessLayer { get; set; }
        
        public ObservableCollection<Recipe> Soups { get; set; }

        public ObservableCollection<Recipe> MainCourses { get; set; }

        public ObservableCollection<Recipe> Desserts { get; set; }



        public MyRecipeBook(IRecipeManager businessLayer)
        {
            BusinessLayer = businessLayer;
            Recipes = BusinessLayer.GetRecipes();
            RecipeTypes = BusinessLayer.GetRecipeTypes();
            RawMaterials = BusinessLayer.GetRawMaterial();
            Units = BusinessLayer.GetUnits();
            Soups = new ObservableCollection<Recipe>(Recipes.FindAll(r => r.Type.Name == "Leves"));
            MainCourses = new ObservableCollection<Recipe>(Recipes.FindAll(r => r.Type.Name == "Főétel"));
            Desserts = new ObservableCollection<Recipe>(Recipes.FindAll(r => r.Type.Name == "Desszert"));
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
