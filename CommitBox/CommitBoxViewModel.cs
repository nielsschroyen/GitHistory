using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using LibGit2Sharp;

namespace GitHistory.CommitBox
{
    public class CommitBoxViewModel:INotifyPropertyChanged
    {
        private List<Commit> commits;
        private Commit selectedCommit;

        public delegate void SelectedCommitChanged(object sender, CommitChangedEventArgs e);

        public event SelectedCommitChanged OnSelectedCommitChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public CommitBoxViewModel(List<Commit> commits )
        {
            this.commits = commits;
        }

        public Commit SelectedCommit
        {
            get { return selectedCommit; }
            set { selectedCommit = value;
                if (OnSelectedCommitChanged != null)
                {
                    OnSelectedCommitChanged(this, new CommitChangedEventArgs(SelectedCommit));
                }
            }
        }
    }
}
