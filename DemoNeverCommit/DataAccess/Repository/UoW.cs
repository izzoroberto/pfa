using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Repository
{
    public class UoW : IUoW
    {
        private readonly ChatContext _context;
        public IAccountRepository Accounts { get; }

        public UoW(ChatContext context)
        {
            _context = context;
            Accounts = new AccountRepository(_context);
        }

        public DbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
          _context.Dispose();
        }
    }
}
