using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using DataAccess.Models;
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


        [Fact]
        public void Test()
        {
            using (var ctx = new SchoolContext())
            {
                using (var dbContextTransaction = ctx.Database.BeginTransaction())
                {
                    try
                    {

                        //ARRANGE
                        Student s = new Student();
                        s.StudentName = "BillTest";
                        var res = _sendEmailStub.Stub(se => se.Send("", "", "")).IgnoreArguments().Return(true);

                        //ACT
                        ctx.Students.Add(s);
                        ctx.SaveChanges();
                        
                        //ASSERT
                        var inserted = ctx.Students.SingleOrDefault(x => x.StudentID == s.StudentID);
                        Assert.NotNull(inserted);

                    }
                    finally
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }

        [Fact]
        public void Test2()
        {
            using (var ctx = new SchoolContext())
            {
                using (var dbContextTransaction = ctx.Database.BeginTransaction())
                {
                    try
                    {

                        //ARRANGE
                        Student s = new Student();
                        s.StudentName = "BillTest";
                        var res = _sendEmailStub.Stub(se => se.Send("", "", "")).IgnoreArguments().Return(true);

                        //ACT
                        ctx.Students.Add(s);
                        ctx.SaveChanges();

                        //ASSERT
                        var inserted = ctx.Students.SingleOrDefault(x => x.StudentID == s.StudentID);
                        Assert.NotNull(inserted);

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
