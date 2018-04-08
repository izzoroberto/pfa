using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Repository;
using Infrastructure;

namespace DataAccess.Services
{
    public class AccountService : IAccountService
    {
        readonly IAccountRepository _accountRepository;
        private readonly ISendEmail _sendEmail;
        private readonly ChatContext _chatContext;
        public AccountService(ISendEmail SendEmail, IAccountRepository accountRepository, ChatContext chatContext)
        {
            _sendEmail = SendEmail;
            _accountRepository = accountRepository;
            _chatContext = chatContext;
        }



        public Account AddAccount(Account account, string email)
        {

            //todo Add  businnes logic for new account
            using (var uow = new UoW(_chatContext))
            {
                using (var dbContextTransaction = uow.BeginTransaction())
                {
                    try
                    {
                        _accountRepository.Add(account);
                        uow.SaveChanges();
                        dbContextTransaction.Commit();
                        _sendEmail.Send("from", email, "message");
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
            return account;
        }
    }
}
