using System.Collections.Generic;
using GitHistory.Functions;
using LibGit2Sharp;

namespace GitHistory.CommitBox
{
    public class CommitBoxViewModel:NotifyPropertyChangedBase
    {
        private List<Commit> commits;

        private List<Commit> selectedCommits;
        public List<Commit> SelectedCommits
        {
            get { return selectedCommits; }
            set { selectedCommits = value;

            if (OnSelectedCommitsChanged != null && value != null)
            {

                OnSelectedCommitsChanged(this, new CommitChangedEventArgs(SelectedCommits));
            }
            }
        }

        public delegate void SelectedCommitChanged(object sender, CommitChangedEventArgs e);

        public List<Commit> Commits
        {
            get { return commits; }
            set
            {
                commits = value;
                NotifyPropertyChanged(() => Commits);
            }
        }

        public event SelectedCommitChanged OnSelectedCommitsChanged;

        public CommitBoxViewModel(List<Commit> commits )
        {
            this.commits = commits;
        }

    }
}
