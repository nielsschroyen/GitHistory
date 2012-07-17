using LibGit2Sharp;

namespace GitHistory.Functions
{
   public class WebCommitBuilder
    {

       public static string CreateGitWebUrl(Commit commit)
       {
           return @"https://github.com/nielsschroyen" + "/GitHistory/commit/" + commit.Sha;
       }
    }
}
