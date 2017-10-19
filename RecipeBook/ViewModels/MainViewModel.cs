using System.ComponentModel;
using RecipeBook.Models;
using RecipeBookBLL.Models;
using RecipeBookInterfaces.Models.Tables;

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

        public void AddRecipe()
        {
            var recipe = new Recipe();            
            recipeBook.AddRecipe(recipe);
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
