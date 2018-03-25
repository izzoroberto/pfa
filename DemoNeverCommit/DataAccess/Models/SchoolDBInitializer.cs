using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataAccess.Models
{
    //public class SchoolDBInitializer : DropCreateDatabaseIfModelChanges<SchoolContext>
    public class SchoolDBInitializer : DropCreateDatabaseAlways<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            IList<Course> courses = new List<Course>();
            courses.Add(new Course() { CourseName = "Course1" });
            context.Courses.AddRange(courses);

            IList<Grade> grades = new List<Grade>();
            grades.Add(new Grade() { GradeName = "Grade 1", Section = "A" });
            grades.Add(new Grade() { GradeName = "Grade 1", Section = "B" });
            grades.Add(new Grade() { GradeName = "Grade 1", Section = "C" });
            grades.Add(new Grade() { GradeName = "Grade 2", Section = "A" });
            grades.Add(new Grade() { GradeName = "Grade 2", Section = "B" });
            grades.Add(new Grade() { GradeName = "Grade 2", Section = "C" });
            grades.Add(new Grade() { GradeName = "Grade 3", Section = "A" });
            grades.Add(new Grade() { GradeName = "Grade 3", Section = "B" });
            grades.Add(new Grade() { GradeName = "Grade 3", Section = "C" });
            context.Grades.AddRange(grades);

            IList<Student> students = new List<Student>();
            students.Add(new Student()
            {
                StudentName = "Student1",
                DateOfBirth = new DateTime(1977, 01, 01),
                Weight = 77,
                Height = 177,
                CurrentGrade = grades[0]
            });
            context.Students.AddRange(students);




            base.Seed(context);
        }
    }
}