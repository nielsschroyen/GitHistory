using LibGit2Sharp;

namespace GitHistory.Functions
{
   public class WebCommitBuilder
    {

       public static string CreateGitWebUrl(Commit commit)
       {

           return WebAddress + "/commit/" + commit.Sha;
       }

       public static string WebAddress
       {
           get { return Properties.Settings.Default.WebLocation; }
       }
    }
}
