using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IUoW : IDisposable
    {
        IAccountRepository Accounts { get; }
        void SaveChanges();
        DbContextTransaction BeginTransaction();
    }
}
