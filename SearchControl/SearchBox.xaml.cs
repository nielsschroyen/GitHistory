using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
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
            Search();
        }

        private void Search()
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

        private void ComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Search();
        }

        private void ComboBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var searchBoxViewModel = DataContext as SearchBoxViewModel;
                if (searchBoxViewModel != null)
                {
                    searchBoxViewModel.Comment = ((TextBox) sender).Text;
                    searchBoxViewModel.DoSearch();
                }
            }
        }
    }
}
