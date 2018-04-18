using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DemoNeverCommitXunitTest.Integration
{
    [CollectionDefinition("MyCollection")]
    public  class MyCollectionDefinition :  ICollectionFixture<MyFixture1>, ICollectionFixture<MyFixture2>
    {
    }
}
