﻿using RecipeBookInterfaces.EntryPoints;
using RecipeBookInterfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Models
{
    public class MyRecipeBook : IMyRecipeBook
    {
        public List<Recipe> Recipes { get; set; }

        public IRecipeManager BusinessLayer { get; set; }

        public MyRecipeBook(IRecipeManager businessLayer)
        {
            this.BusinessLayer = businessLayer;
            Recipes = this.BusinessLayer.GetRecipes();
        }

        public void Add(Recipe recipe)
        {
            if (!Recipes.Contains(recipe))
            {
                Recipes.Add(recipe);
                BusinessLayer.AddRecipe(recipe);
            }
        }

        public void Delete(Recipe recipe)
        {
            if (Recipes.Contains(recipe))
            {
                Recipes.Remove(recipe);
                BusinessLayer.DeleteRecipe(recipe);
            }
        }
    }
}
