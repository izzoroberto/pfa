using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using ContosoUniversity.DAL;
using ContosoUniversity.Models;
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
                        Department d = new Department();
                        d.Name = "gastone";
                        d.StartDate = DateTime.Now;
                        var res = _sendEmailStub.Stub(se => se.Send("", "", "")).IgnoreArguments().Return(true);

                        //ACT
                        ctx.Departments.Add(d);
                        ctx.SaveChanges();
                        
                        //ASSERT
                        var inserted = ctx.Departments.SingleOrDefault(x => x.DepartmentID == d.DepartmentID);
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
                        Department d = new Department();
                        d.Name = "gastone";
                        d.StartDate = DateTime.Now;
                        var res = _sendEmailStub.Stub(se => se.Send("", "", "")).IgnoreArguments().Return(true);

                        //ACT
                        ctx.Departments.Add(d);
                        ctx.SaveChanges();

                        //ASSERT
                        var inserted = ctx.Departments.SingleOrDefault(x => x.DepartmentID == d.DepartmentID);
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
