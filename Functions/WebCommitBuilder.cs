using System.Collections.Generic;
using System.Linq;
using LibGit2Sharp;

namespace GitHistory.Functions
{
   public class WebCommitBuilder
    {

       public static string CreateGitWebUrl(List<Commit> commits)
       {
           var nbCommits = commits.Count;

           if(nbCommits == 0)
           {
               return WebAddress;
           }

           if (nbCommits == 1)
           {
               return WebAddress + "/commit/" + commits.First().Sha;
           }

           var orderedCommits = commits.OrderBy(commit => commit.Committer.When);
           var firstCommit = orderedCommits.First();
           var lastCommit = orderedCommits.Last();

           return WebAddress + "/compare/" + firstCommit.Sha + "..." + lastCommit.Sha;

       }

       public static string WebAddress
       {
           get
           {
               return Properties.Settings.Default.WebLocation;
           }
       }
    }
}
