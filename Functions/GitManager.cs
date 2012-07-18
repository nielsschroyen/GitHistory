using System;
using System.Collections.Generic;
using System.Linq;
using LibGit2Sharp;

namespace GitHistory.Functions
{
    public class GitManager
    {
  
        public List<string> Users
        {
            get
            {
                using (var repo = new Repository(RepositoryLocation))
                {
                    return repo.Head.Commits.Select(commit => commit.Committer.Name).Distinct().ToList();
                }
            }
        }

        public string RepositoryLocation { get { return Properties.Settings.Default.LocalGit; } }

        public List<Commit> Commits
        {
            get
            {
                using (var repo = new Repository(RepositoryLocation))
                {
                   return repo.Head.Commits.ToList();
                }
            }
        }

        public List<Commit> SearchCommits(Func<Commit, bool>  filter)
        {
            using (var repo = new Repository(RepositoryLocation))
            {
              return  repo.Head.Commits.Where(filter).ToList();
            }
        }
    }
}
