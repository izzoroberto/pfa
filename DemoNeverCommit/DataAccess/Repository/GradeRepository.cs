using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Models;

namespace DataAccess.Repository
{
   
    public class GradeRepository : Repository<Grade, int>, IGradeRepository
    {
        private readonly SchoolContext _dbContext;

        public GradeRepository(SchoolContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Grade> FindSection(string text)
        {
            //compare having this statement in a business class compared
            //to invoking the repository methods. Which says more?
            return _dbContext.Grades.Where(x => x.Section == text).ToList();
        }

        public IEnumerable<Grade> GetAll()
        {
            //compare having this statement in a business class compared
            //to invoking the repository methods. Which says more?
            return _dbContext.Grades;
        }

       
    }
}
