using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Repository;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var uow = new UoW(new ChatContext()))
            {
                using (var dbContextTransaction = uow.BeginTransaction())
                {
                    try
                    {
                        var accounts = uow.Accounts.GetAll();
                        Account account = new Account();
                        account.UserName = "roberto";
                        account.Password = "izzo";
                        uow.Accounts.Add(account);
                        uow.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch(Exception ex)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
            Console.WriteLine("Demo complete.");
            Console.ReadLine();
        }
    }
}
