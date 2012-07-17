using System.Windows;
using System.Windows.Controls;

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
            if(searchBoxViewModel != null)
            {
                searchBoxViewModel.DoSearch();
            }
        }
    }
}
