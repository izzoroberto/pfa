using System.Data.Entity.ModelConfiguration;
using DataAccess.Models;

namespace DataAccess.Mapping
{
    public class AccountMap : EntityTypeConfiguration<Account>
    {
        public AccountMap()
        {
            this.ToTable("Account")
                .HasKey<int>(x => x.AccountID);

            this.Property(s => s.UserName)
                .HasColumnName("UserName")
                .IsRequired()
                .HasMaxLength(50);

            this.Property(s => s.Password)
             .IsRequired()
             .HasMaxLength(10);


            // Configure a one-to-one relationship between Account & Profile
            this.HasOptional(a => a.Profile) // Mark Account.Address property optional (nullable)
                .WithRequired(p => p.Account); // Mark Profile.Account property as required (NotNull).


            //this.HasRequired<Group>(s => s.CurrentGrade)
            //.WithMany(g => g.Students)
            //.HasForeignKey<int>(s => s.CurrentGradeId);

            this.HasMany<Message>(a => a.Messages)
               .WithRequired(m => m.Account)
               .HasForeignKey<int>(m => m.AccountId)
               .WillCascadeOnDelete();

            this.HasMany<Group>(s => s.Groups)
                .WithMany(c => c.Accounts)
                .Map(cs =>
                {
                    cs.MapLeftKey("AccountRefId");
                    cs.MapRightKey("GroupRefId");
                    cs.ToTable("AccountGroup");
                });

        }
    }
}