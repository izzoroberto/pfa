namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changestudentTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.StudentInfo", newName: "Student");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Student", newName: "StudentInfo");
        }
    }
}
