using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
  public  class LogData :ILogData
    {
        public void LogThis(string content)
        {
            Console.WriteLine(content);
        }
    }

    public interface ILogData
    {
        void LogThis(string content);
    }
}
