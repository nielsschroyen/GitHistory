using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using GitHistory.Settings;

namespace GitHistory.SearchControl
{
    /// <summary>
    /// Interaction logic for SearchBox.xaml
    /// </summary>
    public partial class SearchBox : UserControl
    {
        public SearchBox()
        {
            InitializeComponent();
        }

        private void SearchClicked(object sender, RoutedEventArgs e)
        {
            var searchBoxViewModel = DataContext as SearchBoxViewModel;
            if (searchBoxViewModel != null)
            {
                searchBoxViewModel.DoSearch();
            }
        }

        private void SettingsClicked(object sender, RoutedEventArgs e)
        {
            var searchBoxViewModel = DataContext as SearchBoxViewModel;
            if (searchBoxViewModel != null)
            {
                searchBoxViewModel.SettingsClick();
            }
           

        }
    }
}
