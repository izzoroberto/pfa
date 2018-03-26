using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UoW : IUoW
    {
        private readonly DbContext _context;

        public UoW(DbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {

        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
