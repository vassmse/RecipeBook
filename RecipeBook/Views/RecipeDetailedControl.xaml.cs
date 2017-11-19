using RecipeBookInterfaces.Models.Tables;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace RecipeBook.Views
{
    public sealed partial class RecipeDetailedControl : UserControl
    {

        public Recipe MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as Recipe; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(Recipe), typeof(RecipeDetailedControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public RecipeDetailedControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as RecipeDetailedControl;
            control.ForegroundElement.ChangeView(0, 0, 1);            
        }

                
    }
}
