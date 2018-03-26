using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Repository
{
   
    public interface IGradeRepository : IRepository<Grade, int>
    {
        IEnumerable<Grade> FindSection(string text);
        IEnumerable<Grade> GetAll();

    }
}
