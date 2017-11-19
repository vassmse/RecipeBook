﻿using System.ComponentModel;
using RecipeBook.Models;
using RecipeBookBLL.Models;
using RecipeBookInterfaces.Models.Tables;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;
using RecipeBookInterfaces.EntryPoints;
using System.Windows.Input;
using System;

namespace RecipeBook.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Properties

        private IRecipeManager _businessLayer { get; set; }

        private Recipe newRecipe;

        public ICommand AddEmployeeCommand { get; set; }

        public Recipe NewRecipe
        {
            get { return newRecipe; }
            set
            {
                newRecipe = value;
                RaisePropertyChanged("NewRecipe");
            }
        }

        private MyRecipeBook recipeBook;
        public MyRecipeBook RecipeBook
        {
            get { return recipeBook; }
            set
            {
                recipeBook = value;
                RaisePropertyChanged("RecipeBook");
            }
        }

        private Recipe selectedRecipe;
        public Recipe SelectedRecipe
        {
            get { return selectedRecipe; }
            set
            {
                selectedRecipe = value;
                RaisePropertyChanged("SelectedRecipe");
            }
        }

        private ObservableCollection<Recipe> selectedRecipes;
        public ObservableCollection<Recipe> SelectedRecipes
        {
            get { return new ObservableCollection<Recipe>(RecipeBook.Recipes.Where(r => r.Type == SelectedRecipe.Type)); }
            set
            {
                selectedRecipes = value;
                RaisePropertyChanged("SelectedRecipes");
            }
        }

        #endregion

        #region Constructor

        public MainViewModel()
        {
            _businessLayer = new RecipeManager();
            RecipeBook = new MyRecipeBook(_businessLayer);
            SelectedRecipe = RecipeBook.Recipes[0];
            NewRecipe = new Recipe();
        }

        #endregion

        #region Public methods

        public void AddRecipe()
        {
            RecipeBook.AddRecipe(NewRecipe);
            SelectedRecipe = NewRecipe;
            NewRecipe = new Recipe();            
            SelectedRecipes = new ObservableCollection<Recipe>(RecipeBook.Recipes.Where(r => r.Type == SelectedRecipe.Type));
        }

        public void AddIngredient()
        {
            NewRecipe.Ingredients.Add(new Ingredient());
        }

        public void RemoveIngredient()
        {
            if (NewRecipe.Ingredients.Count > 1)
                NewRecipe.Ingredients.RemoveAt(NewRecipe.Ingredients.Count - 1);
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
