using System.Collections.Generic;
using System.Windows.Controls;
using GitHistory.CommitBox;
using GitHistory.SearchControl;

namespace GitHistory.Functions
{
   public class GitHistoryController
    {
       private readonly WebBrowser webBrowserControl;
       private readonly SearchBox searchBoxControl;
       private readonly CommitBoxControl commitBoxControl;
       private readonly GitManager gitManager;

       public GitHistoryController(WebBrowser webBrowserControl, SearchBox searchBoxControl, CommitBoxControl commitBoxControl)
       {
           this.webBrowserControl = webBrowserControl;
           this.searchBoxControl = searchBoxControl;
           this.commitBoxControl = commitBoxControl;
           this.webBrowserControl.Navigate(@"https://github.com/nielsschroyen/GitHistory/commit/8ae80bdbdde857590f51738713300773de4ff22e");

           gitManager = new GitManager(@"C:/git/wave");

           InitSearchBox();
           InitCommitBox();
       }

       private void InitCommitBox()
       {
           var commitBoxviewModel = new CommitBoxViewModel(gitManager.Commits);
           commitBoxviewModel.OnSelectedCommitChanged += SelectedCommitChanged;
           commitBoxControl.DataContext = commitBoxviewModel;
       }


       private void InitSearchBox()
       {
           var users = new List<string> {""};
           users.AddRange(gitManager.Users);
           var searchBoxViewModel = new SearchBoxViewModel(users);
           searchBoxViewModel.Search += Search;
           searchBoxControl.DataContext = searchBoxViewModel;
       }

       void Search(object sender, SearchEventArgs e)
       {
           gitManager.SearchCommits(e.CommitFilter);
       }

       void SelectedCommitChanged(object sender, CommitChangedEventArgs commitChangedEventArgs)
       {
           webBrowserControl.Navigate(WebCommitBuilder.CreateGitWebUrl(commitChangedEventArgs.Commit));
       }
    }
}
