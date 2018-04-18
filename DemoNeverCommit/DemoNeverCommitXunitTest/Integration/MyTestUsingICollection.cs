using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DemoNeverCommitXunitTest.Integration
{
    [Collection("MyCollection")]
    public class MyTestUsingICollection
    {
        public MyTestUsingICollection(MyFixture1 myFixture1, MyFixture2 myFixture2)
        {
                
        }
    }
}
