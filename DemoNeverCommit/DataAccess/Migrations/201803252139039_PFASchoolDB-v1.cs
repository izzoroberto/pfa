namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PFASchoolDBv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.StudentInfo",
                c => new
                    {
                        Weight = c.Single(nullable: false),
                        StudentID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        DateOfBirth = c.DateTime(),
                        Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RowVersion = c.Binary(),
                        CurrentGradeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Grade", t => t.CurrentGradeId, cascadeDelete: true)
                .Index(t => t.CurrentGradeId);
            
            CreateTable(
                "dbo.StudentAddress",
                c => new
                    {
                        StudentAddressId = c.Int(nullable: false),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        Zipcode = c.Int(nullable: false),
                        State = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.StudentAddressId)
                .ForeignKey("dbo.StudentInfo", t => t.StudentAddressId)
                .Index(t => t.StudentAddressId);
            
            CreateTable(
                "dbo.Grade",
                c => new
                    {
                        GradeId = c.Int(nullable: false, identity: true),
                        GradeName = c.String(),
                        Section = c.String(),
                    })
                .PrimaryKey(t => t.GradeId);
            
            CreateTable(
                "dbo.StudentCourse",
                c => new
                    {
                        StudentRefId = c.Int(nullable: false),
                        CourseRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentRefId, t.CourseRefId })
                .ForeignKey("dbo.StudentInfo", t => t.StudentRefId, cascadeDelete: true)
                .ForeignKey("dbo.Course", t => t.CourseRefId, cascadeDelete: true)
                .Index(t => t.StudentRefId)
                .Index(t => t.CourseRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentInfo", "CurrentGradeId", "dbo.Grade");
            DropForeignKey("dbo.StudentCourse", "CourseRefId", "dbo.Course");
            DropForeignKey("dbo.StudentCourse", "StudentRefId", "dbo.StudentInfo");
            DropForeignKey("dbo.StudentAddress", "StudentAddressId", "dbo.StudentInfo");
            DropIndex("dbo.StudentCourse", new[] { "CourseRefId" });
            DropIndex("dbo.StudentCourse", new[] { "StudentRefId" });
            DropIndex("dbo.StudentAddress", new[] { "StudentAddressId" });
            DropIndex("dbo.StudentInfo", new[] { "CurrentGradeId" });
            DropTable("dbo.StudentCourse");
            DropTable("dbo.Grade");
            DropTable("dbo.StudentAddress");
            DropTable("dbo.StudentInfo");
            DropTable("dbo.Course");
        }
    }
}
