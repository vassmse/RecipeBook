using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp;
using RecipeBookInterfaces.Models;
using RecipeBookBLL.EntryPoints;
using RecipeBook.Models;

namespace RecipeBook.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public RecipeManager BusinessLayer { get; set; }

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

        

        public MainViewModel()
        {
            BusinessLayer = new RecipeManager();
            RecipeBook = new MyRecipeBook(BusinessLayer);
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
