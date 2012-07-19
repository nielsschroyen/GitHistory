using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Awesomium.Windows.Controls;
using GitHistory.CommitBox;
using GitHistory.SearchControl;
using GitHistory.Settings;

namespace GitHistory.Functions
{
   public class GitHistoryController
    {
       private readonly WebControl webBrowserControl;
       private readonly SearchBox searchBoxControl;
       private readonly CommitBoxControl commitBoxControl;
       private GitManager gitManager;
       private CommitBoxViewModel commitBoxviewModel;

       public GitHistoryController(WebControl webBrowserControl, SearchBox searchBoxControl, CommitBoxControl commitBoxControl)
       {
           this.webBrowserControl = webBrowserControl;
           this.searchBoxControl = searchBoxControl;
           this.commitBoxControl = commitBoxControl;
           Init();

       }

       private void Init()
       {
           gitManager = new GitManager();
           webBrowserControl.LoadURL(gitManager.RepositoryLocation);
           InitSearchBox();
           InitCommitBox();
       }

       private void InitCommitBox()
       {
           commitBoxviewModel = new CommitBoxViewModel(gitManager.Commits);
           commitBoxviewModel.OnSelectedCommitsChanged += SelectedCommitsChanged;
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
           var bitmap = new BitmapImage();
           bitmap.BeginInit();
           bitmap.UriSource = new Uri("pack://application:,,,/GitHistory;component/GitHub.ico");
           bitmap.EndInit();

           var settingsControlViewModel = new SettingsControlViewModel();
           var window = new Window
                            {
                                Content = new SettingsControl {DataContext = settingsControlViewModel},
                                Title = "Settings",
                                Width = 420,
                                Height = 140,
                                ResizeMode = ResizeMode.NoResize,
                                Icon = bitmap
                            };
           window.Show();
           window.Activate();

           settingsControlViewModel.Saved += (o, args) =>  SettingsSaved(window);
       }

       private void SettingsSaved(Window window)
       {
           window.Cursor = Cursors.Wait;
           Init();
           window.Cursor = Cursors.Arrow;
           window.Close();
        
       }


       void Search(object sender, SearchEventArgs e)
       {
           var searchCommits = gitManager.SearchCommits(e.CommitFilter);
           commitBoxviewModel.Commits = searchCommits;
       }

       void SelectedCommitsChanged(object sender, CommitChangedEventArgs commitChangedEventArgs)
       {
           webBrowserControl.LoadURL(WebCommitBuilder.CreateGitWebUrl(commitChangedEventArgs.Commits));
       }


    }
}
