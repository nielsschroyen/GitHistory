using System;
using LibGit2Sharp;

namespace GitHistory.CommitBox
{
    public class CommitChangedEventArgs : EventArgs
    {
        private readonly Commit commit;

        public CommitChangedEventArgs(Commit commit)
        {
            this.commit = commit;
        }

        public Commit Commit
        {
            get { return commit; }
        }
    }
}