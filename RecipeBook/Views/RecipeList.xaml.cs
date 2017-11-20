using RecipeBook.ViewModels;
using RecipeBookInterfaces.Models.Tables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RecipeBook.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RecipeList : Page
    {

        MainViewModel ViewModel = new MainViewModel();
        public RecipeList()
        {
            InitializeComponent();
            DataContext = ViewModel;            
        }

        private void RecipeGrid_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            var baseobj = sender as FrameworkElement;
            var selectedRecipe = baseobj.DataContext as Recipe;
            ViewModel.SelectedRecipe = selectedRecipe;

            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(PivotPage));
        }
    }
}
