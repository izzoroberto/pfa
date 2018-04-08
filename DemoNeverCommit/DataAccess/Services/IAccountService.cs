using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Services
{
public interface IAccountService
{
    Account AddAccount(Account account, string email);
}
}
