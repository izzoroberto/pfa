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
        private AccountService sut;
        private ISendEmail mockmail;
        private ILogData logData;

        public AccountServiceTest()
        {
            _stubAccountRepository = MockRepository.GenerateStub<IAccountRepository>();
            mockmail = MockRepository.GenerateMock<ISendEmail>();
            logData = MockRepository.GenerateMock<ILogData>();
            sut = new AccountService(mockmail, _stubAccountRepository, logData, new ChatContext());
        }

        [Fact]
        public void GivenNewAccount_WhenInsert_ThenSendEmail()
        {
            //ARRANGE
            mockmail.Expect(x => x.Send("", "", "")).IgnoreArguments().Return(true);

            //ACT
            sut.AddAccount(new Account(), "");

            //ASSERT
            mockmail.VerifyAllExpectations();
        }

        [Fact]
        public void GivenNewAccount_WhenInsert_ThenSendEmailAndLog()
        {
            //ARRANGE
            mockmail = MockRepository.GenerateStrictMock<ISendEmail>();
            ILogData mocklogData = MockRepository.GenerateStrictMock<ILogData>();
            sut = new AccountService(mockmail, _stubAccountRepository, mocklogData, new ChatContext());
            mockmail.Expect(x => x.Send("", "", "")).IgnoreArguments().Return(true);
            mocklogData.Expect(x => x.LogThis("")).IgnoreArguments();
            
            //ACT
            sut.AddAccount(new Account(), "");

            //ASSERT
            //mockmail.VerifyAllExpectations();
        }

        [Fact(Skip = "Ignore, in progress")]
        public void GivenNewAccount_WhenUpdate_ThenSendEmail()
        {
            //ARRANGE

            //ACT
            sut.AddAccount(new Account(), "@");

            //ASSERT
            mockmail.AssertWasCalled(x => x.Send(Arg<string>.Is.Anything, Arg<string>.Matches(y => y.Contains("@")), Arg<string>.Is.Anything));
        }


        [Fact]
        public void GivenNewAccount_WhenInsertWithEmail_ThenEmailCheckRecipient()
        {
            //ARRANGE
           
            //ACT
            sut.AddAccount(new Account(), "@");

            //ASSERT
            mockmail.AssertWasCalled(x => x.Send(Arg<string>.Is.Anything, Arg<string>.Matches(y =>y.Contains("@")), Arg<string>.Is.Anything));
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
            AccountService sut = new AccountService(new SendEmail(), _stubAccountRepository, logData, new ChatContext());
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
