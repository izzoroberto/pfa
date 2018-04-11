using System;
using System.Collections.Generic;
using System.Data;
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

        public UoW(ChatContext ctx)
        {
            _context = ctx;
        }

        public DbContextTransaction BeginTransaction()
        {
            if (_context.Database.Connection.State.ToString().ToLower() != "open")
            {
                return _context.Database.BeginTransaction();
            }
            else
            {
                return _context.Database.CurrentTransaction;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        //public void Dispose()
        //{
        //    _context.Dispose();
        //}
    }
}
