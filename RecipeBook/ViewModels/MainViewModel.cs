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
        #region Properties

        private RecipeManager _businessLayer { get; set; }

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

        #endregion

        #region Constructor

        public MainViewModel()
        {
            _businessLayer = new RecipeManager();
            RecipeBook = new MyRecipeBook(_businessLayer);
        }

        #endregion

        #region Public methods

        public void Add()
        {
            var recipe = new Recipe();
            recipeBook.Add(recipe);
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
