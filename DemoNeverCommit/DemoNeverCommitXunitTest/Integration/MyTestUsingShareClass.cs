using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DemoNeverCommitXunitTest.Integration
{
    //Class where you want to use shared class instance
    //XUnit executes tests in parallel by default.Having shared state/values between tests can lead to strange behaviour
    //[assembly: CollectionBehavior(DisableTestParallelization = true)]
    public class MyTestUsingShareClass : IClassFixture<MyFixture1>
    {
        private readonly MyFixture1 _fixture;

        public MyTestUsingShareClass(MyFixture1 fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Test()
        {
            // Do something with _fixture
        }
    }
}
