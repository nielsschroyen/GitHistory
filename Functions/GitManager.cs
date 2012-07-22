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

        public bool IsEmpty { get; set; }

        private void InitCache()
        {
            cachedCommits = new List<Commit>();         

            var repo = Repository.Init(RepositoryLocation);
            
            IsEmpty = repo.Info.IsEmpty;
         
            if(!IsEmpty)
            {
                cachedCommits = repo.Head.Commits.ToList();
            }
            repo.Dispose();
            
        }

        private void UpdateCache()
        {
            if(!IsEmpty)
            {
            var firstCacheCommit = cachedCommits.FirstOrDefault();
            Commit firstCommit;

            using (var repo = new Repository(RepositoryLocation))
            {
                firstCommit = repo.Head.Commits.FirstOrDefault();
            

            if(firstCacheCommit == null || firstCommit == null || firstCommit.Committer.When != firstCacheCommit.Committer.When )
            {               
                    cachedCommits = repo.Head.Commits.ToList();                
            }
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
