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

        private string selectedUser;
        public String SelectedUser
        {
            get { return selectedUser; }
            set
            {
                if (!Equals(selectedUser, value))
                {
                    selectedUser = value;
                    DoSearch();
                }
            }
        }

        private string comment;
        public string Comment
        {
            get { return comment; }
            set {

                if (!Equals(comment, value))
            {
                comment = value;
                DoSearch();
            }
            }
        }

        private DateTime? from;
        public DateTime? From
        {
            get { return from; }
            set
            {
                if (from != value)
                {
                    from = value;
                    DoSearch();
                }
            }
        }

        private DateTime? to;
        public DateTime? To
        {
            get { return to; }
            set
            {
                if (to != value)
                {
                    to = value;
                    DoSearch();
                }
            }
        }

        private Func<Commit, bool> CommitFilter
        {
            get { return new CommitFilterBuilder(SelectedUser, Comment, From, To).CreateCommitFilter(); }
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
