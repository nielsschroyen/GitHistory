using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using GitHistory.CommitBox;
using GitHistory.SearchControl;
using GitHistory.Settings;

namespace GitHistory.Functions
{
   public class GitHistoryController
    {
       private readonly WebBrowser webBrowserControl;
       private readonly SearchBox searchBoxControl;
       private readonly CommitBoxControl commitBoxControl;
       private readonly GitManager gitManager;
       private CommitBoxViewModel commitBoxviewModel;

       public GitHistoryController(WebBrowser webBrowserControl, SearchBox searchBoxControl, CommitBoxControl commitBoxControl)
       {
           this.webBrowserControl = webBrowserControl;
           this.searchBoxControl = searchBoxControl;
           this.commitBoxControl = commitBoxControl;
           gitManager = new GitManager();

           Init();

       }

       private void Init()
       {
           webBrowserControl.Navigate(gitManager.RepositoryLocation);
           
           InitSearchBox();
           InitCommitBox();
       }

       private void InitCommitBox()
       {
           commitBoxviewModel = new CommitBoxViewModel(gitManager.Commits);
           commitBoxviewModel.OnSelectedCommitChanged += SelectedCommitChanged;
           commitBoxControl.DataContext = commitBoxviewModel;
       }


       private void InitSearchBox()
       {
           var users = new List<string> {""};
           users.AddRange(gitManager.Users);
           var searchBoxViewModel = new SearchBoxViewModel(users);
           searchBoxViewModel.Search += Search;
           searchBoxViewModel.OpenSettings += OpenSettings;
           searchBoxControl.DataContext = searchBoxViewModel;
       }

       void OpenSettings(object sender, System.EventArgs e)
       {
           var settingsControlViewModel = new SettingsControlViewModel();
           var window = new Window
                            {
                                Content = new SettingsControl {DataContext = settingsControlViewModel},
                                Title = "Settings",
                                Width = 420,
                                Height = 140,
                                ResizeMode = ResizeMode.NoResize
                            };
           window.Show();
           window.Activate();

           settingsControlViewModel.Saved += SettingsSaved;
       }

       void SettingsSaved(object sender, System.EventArgs e)
       {
           Init();
       }

       void Search(object sender, SearchEventArgs e)
       {
           var searchCommits = gitManager.SearchCommits(e.CommitFilter);
           commitBoxviewModel.Commits = searchCommits;
       }

       void SelectedCommitChanged(object sender, CommitChangedEventArgs commitChangedEventArgs)
       {
           webBrowserControl.Navigate(WebCommitBuilder.CreateGitWebUrl(commitChangedEventArgs.Commit));
       }


    }
}
