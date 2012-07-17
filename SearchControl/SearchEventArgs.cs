using System;
using LibGit2Sharp;

namespace GitHistory.SearchControl
{
    public class SearchEventArgs:EventArgs
    {
        public SearchEventArgs(Func<Commit, bool> commitFilter)
        {
            CommitFilter = commitFilter;
        }
        public Func<Commit, bool> CommitFilter { get; private set; }
    }
}