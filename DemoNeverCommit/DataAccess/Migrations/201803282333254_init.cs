namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        AccountID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.AccountID);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        AccountId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MessageID)
                .ForeignKey("dbo.Group", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Account", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Profile",
                c => new
                    {
                        ProfileID = c.Int(nullable: false),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        Zipcode = c.Int(nullable: false),
                        State = c.String(),
                        Country = c.String(),
                        DateOfBirth = c.DateTime(),
                    })
                .PrimaryKey(t => t.ProfileID)
                .ForeignKey("dbo.Account", t => t.ProfileID)
                .Index(t => t.ProfileID);
            
            CreateTable(
                "dbo.AccountGroup",
                c => new
                    {
                        AccountRefId = c.Int(nullable: false),
                        GroupRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AccountRefId, t.GroupRefId })
                .ForeignKey("dbo.Account", t => t.AccountRefId, cascadeDelete: true)
                .ForeignKey("dbo.Group", t => t.GroupRefId, cascadeDelete: true)
                .Index(t => t.AccountRefId)
                .Index(t => t.GroupRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profile", "ProfileID", "dbo.Account");
            DropForeignKey("dbo.Message", "AccountId", "dbo.Account");
            DropForeignKey("dbo.AccountGroup", "GroupRefId", "dbo.Group");
            DropForeignKey("dbo.AccountGroup", "AccountRefId", "dbo.Account");
            DropForeignKey("dbo.Message", "GroupId", "dbo.Group");
            DropIndex("dbo.AccountGroup", new[] { "GroupRefId" });
            DropIndex("dbo.AccountGroup", new[] { "AccountRefId" });
            DropIndex("dbo.Profile", new[] { "ProfileID" });
            DropIndex("dbo.Message", new[] { "GroupId" });
            DropIndex("dbo.Message", new[] { "AccountId" });
            DropTable("dbo.AccountGroup");
            DropTable("dbo.Profile");
            DropTable("dbo.Message");
            DropTable("dbo.Group");
            DropTable("dbo.Account");
        }
    }
}
