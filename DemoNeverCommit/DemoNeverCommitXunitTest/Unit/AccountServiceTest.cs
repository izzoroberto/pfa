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
        private readonly IAccountRepository _stubAccountRepository;

        public AccountServiceTest()
        {
            _stubAccountRepository = MockRepository.GenerateStub<IAccountRepository>();
        }

        [Fact]
        public void GivenNewAccount_WhenInsert_ThenSendEmail()
        {
            //ARRANGE
            var mockEmail = MockRepository.GenerateMock<ISendEmail>();
            mockEmail.Expect(x => x.Send("", "", "")).IgnoreArguments().Return(true);

            //ACT
            AccountService sut = new AccountService(mockEmail, _stubAccountRepository, new ChatContext());
            sut.AddAccount(new Account(), "");

            //ASSERT
            mockEmail.VerifyAllExpectations();
        }
    }
}
