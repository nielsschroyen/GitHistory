using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GitHistory.SearchControl
{
    /// <summary>
    /// Interaction logic for SearchBox.xaml
    /// </summary>
    public partial class SearchBox
    {
        public SearchBox()
        {
            InitializeComponent();
        }

        private void SettingsClicked(object sender, RoutedEventArgs e)
        {
            var searchBoxViewModel = DataContext as SearchBoxViewModel;
            if (searchBoxViewModel != null)
            {
                searchBoxViewModel.SettingsClick();
            }
        }

        private void CommentKeyUp(object sender, KeyEventArgs e)
        {
           
                var searchBoxViewModel = DataContext as SearchBoxViewModel;
                if (searchBoxViewModel != null)
                {
                    searchBoxViewModel.Comment = txtComment.Text;
                }
            
        }
    }
}
