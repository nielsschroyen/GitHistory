using System;
using System.Collections.Generic;
using System.Linq;
using LibGit2Sharp;

namespace GitHistory.Functions
{
    public class GitManager
    {
        private List<Commit> cachedCommits;
        public GitManager()
        {
            InitCache();
        }

        private void InitCache()
        {
            cachedCommits = new List<Commit>();
            using (var repo = new Repository(RepositoryLocation))
            {
                cachedCommits = repo.Head.Commits.ToList();
            }
        }

        private void UpdateCache()
        {
            var firstCacheCommit = cachedCommits.FirstOrDefault();
            var firstCommit = cachedCommits.FirstOrDefault();
            if(firstCacheCommit == null || firstCommit == null || firstCommit.Committer.When != firstCacheCommit.Committer.When )
            {
                using (var repo = new Repository(RepositoryLocation))
                {
                    cachedCommits = repo.Head.Commits.ToList();
                }
            }
        }



        public List<string> Users
        {
            get
            {
                UpdateCache();
                return cachedCommits.Select(commit => commit.Committer.Name).Distinct().ToList();
            }
        }

        public string RepositoryLocation { get { return Properties.Settings.Default.LocalGit; } }

        public List<Commit> Commits
        {
            get
            {
                UpdateCache();
                return cachedCommits;
            }
        }

        public List<Commit> SearchCommits(Func<Commit, bool>  filter)
        {
            UpdateCache();
            return cachedCommits.Where(filter).ToList();
        }
    }
}
