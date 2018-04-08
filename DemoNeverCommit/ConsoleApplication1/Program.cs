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

            try
            {
                ChatContext chatContext = new ChatContext();
                IAccountRepository accountRepository = new AccountRepository(chatContext);
                ISendEmail sendEmail = new SendEmail();
                AccountService accountService = new AccountService(sendEmail, accountRepository, chatContext);

                Account account = new Account();
                account.UserName = "roberto";
                account.Password = "password";
                //todo add email in profile entity
                accountService.AddAccount(account, "email");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex);
                throw;
            }



            Console.WriteLine("Demo complete.");
            Console.ReadLine();
        }
    }
}
