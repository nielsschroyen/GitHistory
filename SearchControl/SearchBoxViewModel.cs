using System;
using System.Collections.Generic;
using LibGit2Sharp;

namespace GitHistory.SearchControl
{
    public class SearchBoxViewModel
    {
        private readonly List<string> users;

        public delegate void SearchClicked(object sender, SearchEventArgs e);
        public event SearchClicked Search;

        public delegate void SettingsClicked(object sender, EventArgs e);
        public event SettingsClicked OpenSettings;

        public SearchBoxViewModel(List<string> users )
        {
            this.users = users;
        }
        
        public List<string> Users
        {
            get { return users; }
        }

        public String SelectedUser { get; set; }

        public string Comment { get; set; }


        private Func<Commit, bool> CommitFilter
        {
            get { return new CommitFilterBuilder(SelectedUser, Comment).CreateCommitFilter(); }
        }

        public void DoSearch()
        {
            if (Search != null)
                Search(this, new SearchEventArgs(CommitFilter));
        }

        public void SettingsClick()
        {
            if (OpenSettings != null)
                OpenSettings(this, new EventArgs());
        }
    }
}
