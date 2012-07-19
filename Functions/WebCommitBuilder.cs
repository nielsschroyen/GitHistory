using System.Linq;
using LibGit2Sharp;

namespace GitHistory.Functions
{
   public class WebCommitBuilder
    {

       public static string CreateGitWebUrl(Commit commit)
       {
           Commit firstCommit;

           using (var repo = new Repository(Properties.Settings.Default.LocalGit))
           {
               firstCommit = repo.Head.Commits.FirstOrDefault();
           }
           if (firstCommit != null) return WebAddress + "/compare/" + commit.Sha + "..." + firstCommit.Sha;
           return "bla";
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
