using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DataAccess.Models;
using DataAccess.Repository;
using DataAccess.Services;
using Infrastructure;
using Rhino.Mocks;
using Xunit;

namespace DemoNeverCommitXunitTest.Integration
{
    [Trait("Category", "Integration")]
    public class AccountServiceTest
    {
        private readonly ISendEmail _sendEmailStub;
        private AccountService _sut;
        private readonly ChatContext _chatContext;
        private readonly IAccountRepository _accountRepository;

        public AccountServiceTest()
        {
            _chatContext = new ChatContext();
            _sendEmailStub = MockRepository.GenerateStub<ISendEmail>();
            _accountRepository = new AccountRepository(_chatContext);
            _sut = new AccountService(_sendEmailStub, _accountRepository, new ChatContext());
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
                        account.Password = "password2";

                        _sendEmailStub.Stub(se => se.Send("", "", "")).IgnoreArguments().Return(true);

                        //ACT
                        var newaccount = _sut.AddAccount(account, null);

                        //ASSERT
                        var insertedAccount = _accountRepository.Get(account.AccountID);
                        Assert.NotNull(insertedAccount);
                        Assert.Equal(insertedAccount.Password, newaccount.Password);
                    }
                    finally
                    {
                        dbContextTransaction.Rollback();
                    }
                }

        }
    }
}
