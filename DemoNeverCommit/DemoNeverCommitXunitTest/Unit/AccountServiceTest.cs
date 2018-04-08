using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Repository;
using DataAccess.Services;
using Infrastructure;
using Rhino.Mocks;
using Xunit;

namespace DemoNeverCommitXunitTest.Unit
{
    [Trait("Category", "Unit")]
    public class AccountServiceTest
    {
        private readonly IAccountRepository _accountRepository;

        public AccountServiceTest()
        {
            _accountRepository = MockRepository.GenerateStub<IAccountRepository>();
        }

        [Fact]
        public void GivenNewAccount_WhenInsert_ThenSendEmail()
        {
            var mockemail = MockRepository.GenerateMock<ISendEmail>();
            mockemail.Expect(x => x.Send("", "", "")).IgnoreArguments().Return(true);

            AccountService accountService = new AccountService(mockemail, _accountRepository, new ChatContext());
            accountService.AddAccount(new Account(), "");
            mockemail.VerifyAllExpectations();
        }
    }
}
