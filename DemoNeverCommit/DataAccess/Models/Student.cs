using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
        }
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }
        public byte[] RowVersion { get; set; }

        //A fully defined relationship
        //nullable fk
        public int CurrentGradeId { get; set; }
        public virtual Grade CurrentGrade { get; set; }

        public virtual StudentAddress Address { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}