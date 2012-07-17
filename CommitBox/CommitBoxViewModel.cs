using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using GitHistory.Functions;
using LibGit2Sharp;

namespace GitHistory.CommitBox
{
    public class CommitBoxViewModel:NotifyPropertyChangedBase
    {
        private List<Commit> commits;
        private Commit selectedCommit;

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

        public event SelectedCommitChanged OnSelectedCommitChanged;

        public CommitBoxViewModel(List<Commit> commits )
        {
            this.commits = commits;
        }

        public Commit SelectedCommit
        {
            get { return selectedCommit; }
            set { selectedCommit = value;
                if (OnSelectedCommitChanged != null && value != null)
                {

                    OnSelectedCommitChanged(this, new CommitChangedEventArgs(SelectedCommit));
                }
            }
        }
    }
}
