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
    public class Class1
    {
        private ISendEmail _sendEmailStub;
        public Class1()
        {
            _sendEmailStub = MockRepository.GenerateStub<ISendEmail>();
        }


        //[Fact]
        //public void Test()
        //{
        //    using (var ctx = new ChatContext())
        //    {
        //        using (var dbContextTransaction = ctx.Database.BeginTransaction())
        //        {
        //            try
        //            {

        //                //ARRANGE

        //                Account s = new Account();
        //                s.UserName = "BillTest";
        //                var res = _sendEmailStub.Stub(se => se.Send("", "", "")).IgnoreArguments().Return(true);

        //                //ACT
        //                ctx.Accounts.Add(s);
        //                ctx.SaveChanges();
                        
        //                //ASSERT
        //                var inserted = ctx.Accounts.SingleOrDefault(x => x.AccountID == s.AccountID);
        //                Assert.NotNull(inserted);

        //            }
        //            finally
        //            {
        //                dbContextTransaction.Rollback();
        //            }
        //        }
        //    }
        //}

        //[Fact]
        //public void Test2()
        //{
        //    using (var ctx = new ChatContext())
        //    {
        //        using (var dbContextTransaction = ctx.Database.BeginTransaction())
        //        {
        //            try
        //            {

        //                //ARRANGE

        //                Account s = new Account();
        //                s.UserName = "BillTest";
        //                var res = _sendEmailStub.Stub(se => se.Send("", "", "")).IgnoreArguments().Return(true);

        //                //ACT
        //                ctx.Accounts.Add(s);
        //                ctx.SaveChanges();

        //                //ASSERT
        //                var inserted = ctx.Accounts.SingleOrDefault(x => x.AccountID == s.AccountID);
        //                Assert.NotNull(inserted);

        //            }
        //            finally
        //            {
        //                dbContextTransaction.Rollback();
        //            }
        //        }
        //    }
        //}

        [Fact]
        public void GivenNewAccount_WhenInsert_ThenReturnNotNull()
        {
            using (var uow = new UoW(new ChatContext()))
            {
                using (var dbContextTransaction = uow.BeginTransaction())
                {
                    try
                    {
                        //ARRANGE
                        Account account = new Account();
                        account.UserName = "roberto";
                        account.Password = "izzo";
                        uow.Accounts.Add(account);
                        var res = _sendEmailStub.Stub(se => se.Send("", "", "")).IgnoreArguments().Return(true);

                        //ACT
                        uow.SaveChanges();

                        //ASSERT
                        var insertedAccount = uow.Accounts.Get(account.AccountID);
                        Assert.NotNull(insertedAccount);
                    }
                    finally
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }



    }
}
