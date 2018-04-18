using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Repository;
using DataAccess.Services;
using Infrastructure;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //i know password  is clear no hash, no salt no pepper ..:)
            try
            {
                ChatContext ctx = new ChatContext();
                IAccountRepository accountRepository = new AccountRepository(ctx);
                ISendEmail sendEmail = new SendEmail();
                ILogData logData = new LogData();
                AccountService accountService = new AccountService(sendEmail, accountRepository, logData, ctx);

                Account account = new Account();
                account.UserName = "rob";
                account.Password = "gerrybello";
                //todo add email in profile entity
                accountService.AddAccount(account, "roberto.izzo@giuneco.it");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex);
                //throw;
            }



            Console.WriteLine("Demo complete.");
            Console.ReadLine();
        }
    }
}
