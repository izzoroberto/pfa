using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DataAccess.Mapping;

namespace DataAccess.Models
{
    public class SchoolContext : DbContext
    {
        //public SchoolContext() : base("PFASchoolDB")
        //{
        //    Database.SetInitializer<SchoolContext>(new SchoolDBInitializer());
        //}

        public SchoolContext()
        {
            //Database.SetInitializer<SchoolContext>(new MigrateDatabaseToLatestVersion<SchoolContext,Migrations.Configuration>());
            //Database.SetInitializer<SchoolContext>(new SchoolDBInitializer());
            Database.SetInitializer<SchoolContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Adds configurations for Student from separate class
            modelBuilder.Configurations.Add(new StudentMap());
            modelBuilder.Configurations.Add(new GradeMap());

            //modelBuilder.Entity<Teacher>()
            //    .MapToStoredProcedures();
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }
    }
}