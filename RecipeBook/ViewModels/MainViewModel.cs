﻿using RecipeBook.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp;

namespace RecipeBook.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
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

        private string test;

        public string Test
        {
            get { return test; }
            set { test = value; RaisePropertyChanged("Test"); }
        }



        public MainViewModel()
        {
            recipeBook = new MyRecipeBook();
            Test = "a";
        }
                

        public void Add()
        {
            var recipe = new Recipe();
            recipeBook.Add(recipe);
        }


        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void RaisePropertyChanged(string propertyName)
        {
            var handlers = PropertyChanged;

            handlers(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}