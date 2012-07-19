using System;
using LibGit2Sharp;

namespace GitHistory.SearchControl
{
   public class CommitFilterBuilder
    {
       private readonly string user;
       private readonly string comment;
       private readonly DateTime? to;
       private readonly DateTime? from;


       public CommitFilterBuilder(string user, string comment, DateTime? from, DateTime? to)
       {
           this.user = user;
           this.comment = comment;
           this.to = to;
           this.from = from;
       }

       public Func<Commit, bool> CreateCommitFilter()
       {
           return CommitFilter;

       }

       public bool CommitFilter(Commit commit)
       {
           return ContainsComment(commit) && ContainsUser(commit) && BeforeDate(commit) && AfterDate(commit);
       }

       private bool ContainsComment(Commit commit)
       {
           if (!string.IsNullOrEmpty(comment))
           {
               return commit.Message.ToLower().Contains(comment.ToLower()) || commit.MessageShort.ToLower().Contains(comment.ToLower()); ;
           }
           return true;
       }

       private bool ContainsUser(Commit commit)
       {
           if (!string.IsNullOrEmpty(user))
           {
               return commit.Committer.Name.Equals(user);
           }
           return true;
       }

       private bool AfterDate(Commit commit)
       {
           if (from != null)
           {
               return commit.Committer.When.Date >= from;
           }
           return true;
       }

       private bool BeforeDate(Commit commit)
       {
           if (to != null)
           {
               return commit.Committer.When.Date <= to;
           }
           return true;
       }
    }
}