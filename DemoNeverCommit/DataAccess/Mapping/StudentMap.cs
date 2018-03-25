using System.Data.Entity.ModelConfiguration;
using DataAccess.Models;

namespace DataAccess.Mapping
{
    public class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            this.ToTable("Student")
                .HasKey<int>(x => x.StudentID);

            this.Property(s => s.StudentName)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(50);

            this.Property(s => s.Weight)
                .HasColumnOrder(4);

            this.Property(s => s.StudentName)
                .IsConcurrencyToken();

            // Configure a one-to-one relationship between Student & StudentAddress
            this.HasOptional(s => s.Address) // Mark Student.Address property optional (nullable)
                .WithRequired(ad => ad.Student); // Mark StudentAddress.Student property as required (NotNull).

            //this.HasRequired(s => s.Address)
            //    .WithRequiredPrincipal(ad => ad.Student);

            //this.HasRequired<Grade>(s => s.CurrentGrade)
            //.WithMany(g => g.Students)
            //.HasForeignKey<int>(s => s.CurrentGradeId);

            this.HasMany<Course>(s => s.Courses)
                .WithMany(c => c.Students)
                .Map(cs =>
                {
                    cs.MapLeftKey("StudentRefId");
                    cs.MapRightKey("CourseRefId");
                    cs.ToTable("StudentCourse");
                });

        }
    }
}