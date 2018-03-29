using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Repository
{
   public class AccountRepository : Repository<Account>, IAccountRepository
   {
       public AccountRepository(ChatContext context) 
            : base(context)
       {
       }

       public List<Account> GetMessagesFromAccountId(int accountId)
       {
           return ChatContext.Accounts
               .Include(c => c.Messages).ToList();
       }

       public ChatContext ChatContext => Context as ChatContext;
   }
}
