using RecipeBook.Models;
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
        Models.RecipeBook recipeBook;

        public MainViewModel()
        {

        }
                

        public void Add()
        {
            var recipe = new Recipe();
            recipeBook.Add(recipe);
        }



        public event PropertyChangedEventHandler PropertyChanged;
    }
}
