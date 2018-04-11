using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IUoW 
    {
        void SaveChanges();
        DbContextTransaction BeginTransaction();
    }
}
