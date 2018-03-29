using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataAccess.Models
{
    //public class AccountDBInitializer : DropCreateDatabaseIfModelChanges<ChatContext>
    public class AccountDBInitializer : DropCreateDatabaseIfModelChanges<ChatContext>
    {
        protected override void Seed(ChatContext context)
        {
            IList<Account> accounts = new List<Account>();
            accounts.Add(new Account() {UserName = "Account1",Password = "pass" });
            accounts.Add(new Account() { UserName = "Account2", Password = "pass" });
            accounts.Add(new Account() { UserName = "Account3", Password = "pass" });

            context.Accounts.AddRange(accounts);

            base.Seed(context);
        }
    }
}