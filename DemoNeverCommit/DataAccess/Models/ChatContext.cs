using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DataAccess.Mapping;

namespace DataAccess.Models
{
    public class ChatContext : DbContext
    {
        public ChatContext() : base("ChatContext")
        {
            //Database.SetInitializer<ChatContext>(new AccountDBInitializer());
            Database.SetInitializer<ChatContext>(null);
        }

        //public ChatContext()
        //{
        //    //Database.SetInitializer<ChatContext>(new MigrateDatabaseToLatestVersion<ChatContext, Migrations.Configuration>());
        //    //Database.SetInitializer<ChatContext>(new AccountDBInitializer());
        //    Database.SetInitializer<ChatContext>(null);
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Adds configurations for Account from separate class
            modelBuilder.Configurations.Add(new AccountMap());
            
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Profile> Profiles { get; set; }
    }
}