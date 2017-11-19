using RecipeBookInterfaces.EntryPoints;
using RecipeBookInterfaces.Models;
using RecipeBookInterfaces.Models.Tables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace RecipeBook.Models
{
    public class MyRecipeBook : IMyRecipeBook, INotifyPropertyChanged
    {
        private ObservableCollection<Recipe> recipes;

        public ObservableCollection<Recipe> Recipes
        {
            get { return recipes; }
            set
            {
                recipes = value;
                RaisePropertyChanged("Recipes");
            }
        }        

        public List<RecipeType> RecipeTypes { get; set; }

        public List<RawMaterial> RawMaterials { get; set; }

        public List<string> Units { get; set; }

        public IRecipeManager BusinessLayer { get; set; }


        private ObservableCollection<Recipe> soups;
        public ObservableCollection<Recipe> Soups
        {
            get { return soups; }
            set
            {
                soups = value;
                RaisePropertyChanged("Soups");
            }
        }

        private ObservableCollection<Recipe> mainCourses;
        public ObservableCollection<Recipe> MainCourses
        {
            get { return mainCourses; }
            set
            {
                mainCourses = value;
                RaisePropertyChanged("MainCourses");
            }
        }

        private ObservableCollection<Recipe> desserts;
        public ObservableCollection<Recipe> Desserts
        {
            get { return desserts; }
            set
            {
                desserts = value;
                RaisePropertyChanged("Desserts");
            }
        }

        public MyRecipeBook(IRecipeManager businessLayer)
        {
            BusinessLayer = businessLayer;
            Recipes =  BusinessLayer.GetRecipes();
            RecipeTypes = BusinessLayer.GetRecipeTypes();
            RawMaterials = BusinessLayer.GetRawMaterial();
            Units = BusinessLayer.GetUnits();       

            Soups = new ObservableCollection<Recipe>(Recipes.Where(r => r.Type.Name == "Leves"));
            MainCourses = new ObservableCollection<Recipe>(Recipes.Where(r => r.Type.Name == "Főétel"));
            Desserts = new ObservableCollection<Recipe>(Recipes.Where(r => r.Type.Name == "Desszert"));
        }

        #region BL methods

        public void AddRecipe(Recipe recipe)
        {
            if (!Recipes.Contains(recipe))
            {
                Recipes.Add(recipe);
                BusinessLayer.AddRecipe(recipe);
                Soups = new ObservableCollection<Recipe>(Recipes.Where(r => r.Type.Name == "Leves"));
                MainCourses = new ObservableCollection<Recipe>(Recipes.Where(r => r.Type.Name == "Főétel"));
                Desserts = new ObservableCollection<Recipe>(Recipes.Where(r => r.Type.Name == "Desszert"));
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

        #region PropertyChangedEventHandler

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void RaisePropertyChanged(string propertyName)
        {
            var handlers = PropertyChanged;

            handlers(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
