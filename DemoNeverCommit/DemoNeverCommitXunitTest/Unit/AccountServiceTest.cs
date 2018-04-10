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
            var mockmail = MockRepository.GenerateMock<ISendEmail>();
            mockmail.Expect(x => x.Send("", "", "")).IgnoreArguments().Return(true);

            //ACT
            AccountService sut = new AccountService(mockmail, _stubAccountRepository, new ChatContext());
            sut.AddAccount(new Account(), "");

            //ASSERT
            mockmail.VerifyAllExpectations();
        }

        [Fact(Skip = "Ignore, in progress")]
        public void GivenNewAccount_WhenUpdate_ThenSendEmail()
        {
            //ARRANGE
            var mockmail = MockRepository.GenerateMock<ISendEmail>();
            mockmail.Expect(x => x.Send("", "", "")).IgnoreArguments().Return(true);

           
            //ACT
            AccountService sut = new AccountService(mockmail, _stubAccountRepository, new ChatContext());
            sut.AddAccount(new Account(), "");

            //ASSERT
            mockmail.VerifyAllExpectations();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("pippo")]
        public void GivenSendEmail_WhenNullEmail_ThenThrow(string recipient)
        {
            //ARRANGE
            SendEmail _sut = new SendEmail();
            
            //ACT
            Exception ex = Assert.Throws<ArgumentException>(() => _sut.Send("",recipient,""));
            
            //ASSERT
            Assert.Equal("Error : recipient must be a valid email", ex.Message);
        }

        [Fact]
        public void GivenNewAccount_WhenNullEmail_ThenThrow()
        {
            //ARRANGE
            AccountService sut = new AccountService(new SendEmail(), _stubAccountRepository, new ChatContext());
            var newaccount = new Account()
            {
                UserName = "test",
                Password = "test"
            };

            //ACT
            Exception ex = Assert.Throws<ArgumentException>(() => sut.AddAccount(newaccount, null));

            //ASSERT
            Assert.Equal("Error : recipient must be a valid email", ex.Message);
        }
    }
}
