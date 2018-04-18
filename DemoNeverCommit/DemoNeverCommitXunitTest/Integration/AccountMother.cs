using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DemoNeverCommitXunitTest.Integration
{
   public class AccountMother
    {
       public static Account NewAccount()
        {
            Account account = new Account();
            account.UserName = "roberto";
            account.Password = "password";
            return account;
        }
    }
}
