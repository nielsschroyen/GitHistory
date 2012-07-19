using System;
using System.Collections.Generic;
using LibGit2Sharp;

namespace GitHistory.CommitBox
{
    public class CommitChangedEventArgs : EventArgs
    {
        private readonly List<Commit> commits;

        public CommitChangedEventArgs(List<Commit> commits)
        {
            this.commits = commits;
        }

        public List<Commit> Commits
        {
            get { return commits; }
        }
    }
}