using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Mapping
{
    public class GradeMap : EntityTypeConfiguration<Grade>
    {
        public GradeMap()
        {
            this.HasMany<Student>(g => g.Students)
                .WithRequired(s => s.CurrentGrade)
                .HasForeignKey<int>(s => s.CurrentGradeId)
                .WillCascadeOnDelete();

        }
    }
}
