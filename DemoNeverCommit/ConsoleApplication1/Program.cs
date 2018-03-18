using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoUniversity.DAL;
using ContosoUniversity.Models;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new SchoolContext())
            {
                using (var dbContextTransaction = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        Department d = new Department();
                        d.Name = "gastone";
                        d.StartDate = DateTime.Now;
                        ctx.Departments.Add(d);
                        ctx.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw;
                    }
                }
            }

            Console.WriteLine("Demo complete.");
            Console.ReadLine();
        }
    }
}
