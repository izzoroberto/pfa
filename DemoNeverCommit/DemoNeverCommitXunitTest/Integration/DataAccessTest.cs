using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using DataAccess;
using DataAccess.Models;
using DataAccess.Repository;
using Infrastructure;
using Rhino.Mocks;
using Xunit;

namespace DemoNeverCommitXunitTest.Integration
{
    [Trait("Category","Integration")]
    public class DataAccesTest
    {
        private readonly ChatContext _chatContext;
        private readonly IAccountRepository _accountRepository;
        public DataAccesTest()
        {
            _chatContext = new ChatContext();
            _accountRepository = new AccountRepository(_chatContext);
        }
      

        [Fact]
        public void GivenNewAccount_WhenInsert_ThenReturnNotNull()
        {
            var uow = new UoW(_chatContext);
                using (var dbContextTransaction = uow.BeginTransaction())
                {
                    try
                    {
                        //ARRANGE
                        Account account = new Account();
                        account.UserName = "roberto";
                        account.Password = "password";
                        _accountRepository.Add(account);

                        //ACT
                        uow.SaveChanges();

                        //ASSERT
                        var insertedAccount = _accountRepository.Get(account.AccountID);
                        Assert.NotNull(insertedAccount);
                        Assert.Equal(insertedAccount.Password, account.Password);
                    }
                    finally
                    {
                        dbContextTransaction.Rollback();
                    }
            }
        }

        [Fact]
        public void GivenAccount_WhenUpdate_ThenReturnUpdated()
        {
            var uow = new UoW(_chatContext);
            using (var dbContextTransaction = uow.BeginTransaction())
                {
                    try
                    {
                        //ARRANGE
                        string newPassword = "password1";
                        Account account = new Account();
                        account.UserName = "roberto";
                        account.Password = "password";
                        _accountRepository.Add(account);
                        uow.SaveChanges();

                        //ACT
                        var attachedAccount = _accountRepository.Get(account.AccountID);
                        attachedAccount.Password = newPassword;
                        uow.SaveChanges();

                        //ASSERT
                        var updatedAccount = _accountRepository.Get(account.AccountID);
                        Assert.NotNull(updatedAccount);
                        Assert.Equal(updatedAccount.Password, newPassword);
                    }
                    finally
                    {
                        dbContextTransaction.Rollback();
                    }
                }
        }

    }
}
