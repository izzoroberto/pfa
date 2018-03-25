using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

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
                        var student = new Student() { StudentName = "Bill" };
                        var grade = ctx.Grades.FirstOrDefault(x => x.Section == "A");
                        student.CurrentGrade = grade;
                        ctx.Students.Add(student);
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
