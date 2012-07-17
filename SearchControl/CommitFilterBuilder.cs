using System;
using LibGit2Sharp;

namespace GitHistory.SearchControl
{
   public class CommitFilterBuilder
    {
       private readonly string user;
       private readonly string comment;

       public CommitFilterBuilder(string user, string comment)
       {
           this.user = user;
           this.comment = comment;
       }

       public Func<Commit, bool> CreateCommitFilter()
       {
           return CommitFilter;

       }

       public bool CommitFilter(Commit commit)
       {
           return ContainsComment(commit) && ContainsUser(commit);
       }

       private bool ContainsComment(Commit commit)
       {
           if (comment != "")
           {
               return commit.Message.ToLower().Contains(comment.ToLower());
           }
           return true;
       }

       private bool ContainsUser(Commit commit)
       {
           if (user != "")
           {
               return commit.Committer.Name.Equals(user);
           }
           return true;
       }
    }
}