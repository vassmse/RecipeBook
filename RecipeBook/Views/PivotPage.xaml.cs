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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RecipeBook.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PivotPage : Page
    {
        MainViewModel ViewModel = new MainViewModel();

        public PivotPage()
        {
            NavigationCacheMode = NavigationCacheMode.Required;
            DataContext = ViewModel;
            InitializeComponent();
            MainPivot.CacheMode = null;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            MainPivot.SelectedIndex = 1;
            base.OnNavigatedFrom(e);
        }

        private void mypivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    }
}
