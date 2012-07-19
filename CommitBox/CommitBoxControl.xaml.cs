using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibGit2Sharp;

namespace GitHistory.CommitBox
{
    /// <summary>
    /// Interaction logic for CommitBoxControl.xaml
    /// </summary>
    public partial class CommitBoxControl : UserControl
    {
        public CommitBoxControl()
        {
            InitializeComponent();
        }

        private void ListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var commitBoxViewModel = DataContext as CommitBoxViewModel;

            if(commitBoxViewModel != null)
            {
                var commits = new List<Commit>();
                if (lbCommits.SelectedItems != null)
                {
                    commits.AddRange(lbCommits.SelectedItems.Cast<Commit>());
                }
                commitBoxViewModel.SelectedCommits = commits;
            
            }
        }
    }
}
