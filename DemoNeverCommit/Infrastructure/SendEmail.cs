using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class SendEmail : ISendEmail
    {
        public bool Send(string @from, string to, string message)
        {
            throw new NotImplementedException();
        }
    }

    public interface ISendEmail
    {
        bool Send(string from, string to, string message);
    }
}
