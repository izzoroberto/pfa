﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNeverCommitXunitTest.Integration
{
    public class MyFixture1 : IDisposable
    {
        //public SqlConnection Db { get; private set; }
        public MyFixture1()
        {
            // Setup here
            //Db = new SqlConnection("MyConnectionString");
        }

        public void Dispose()
        {
            // Cleanup here
        }
    }
}
