using RecipeBook.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RecipeBook.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddRecipe : Page
    {
        MainViewModel viewModel = new MainViewModel();

        public AddRecipe()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            viewModel.AddRecipe();
            Console.WriteLine();
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            viewModel.AddIngredient();
        }

        private void RemoveIngredient_Click(object sender, RoutedEventArgs e)
        {
            viewModel.RemoveIngredient();
        }
    }
}
