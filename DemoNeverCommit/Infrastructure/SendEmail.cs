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
            if(to == null)
                throw new ArgumentException("Error : recipient must be a valid email");

            if (!to.Contains("@"))
                throw new ArgumentException("Error : recipient must be a valid email");
            return true;
        }
    }

    public interface ISendEmail
    {
        bool Send(string from, string to, string message);
    }
}
