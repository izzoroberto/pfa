using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DataAccess.Models;
using DataAccess.Repository;
using Infrastructure;

namespace DataAccess.Services
{
    public class AccountService : IAccountService
    {
        readonly IAccountRepository _accountRepository;
        private readonly ISendEmail _sendEmail;
        private readonly ILogData _logData;
        private ChatContext _chatContext;
        public AccountService(ISendEmail SendEmail, IAccountRepository accountRepository,ILogData LogData,  ChatContext ctx)
        {
            _sendEmail = SendEmail;
            _accountRepository = accountRepository;
            _chatContext = ctx;
            _logData = LogData;
        }



        public Account AddAccount(Account account, string email)
        {

            //todo Add  businnes logic for new account
            var uow = new UoW(_chatContext);
            using (var dbContextTransaction = uow.BeginTransaction())
            {
                try
                {
                    _accountRepository.Add(account);
                    uow.SaveChanges();
                    _sendEmail.Send("from", email, "message");
                    _logData.LogThis(DateTime.Now+" insert "+ account.AccountID);
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    //todo some logs
                    dbContextTransaction.Rollback();
                    throw;
                }
            }
            return account;
        }
    }
}
