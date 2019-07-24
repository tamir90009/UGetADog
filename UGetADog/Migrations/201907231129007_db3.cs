namespace UGetADog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        GiverID = c.Int(),
                        Username = c.String(nullable: false),
                        Content = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Givers", t => t.GiverID)
                .Index(t => t.GiverID);
            
            CreateTable(
                "dbo.Givers",
                c => new
                    {
                        GiverID = c.Int(nullable: false, identity: true),
                        UID = c.Int(nullable: false),
                        Phone = c.String(nullable: false),
                        Rating = c.Double(nullable: false),
                        Address = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longtitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.GiverID)
                .ForeignKey("dbo.Users", t => t.UID, cascadeDelete: true)
                .Index(t => t.UID);
            
            CreateTable(
                "dbo.Dogs",
                c => new
                    {
                        DogID = c.Int(nullable: false, identity: true),
                        GID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Age = c.Double(nullable: false),
                        Breed = c.String(nullable: false),
                        Trained = c.Boolean(nullable: false),
                        Immune = c.Boolean(nullable: false),
                        Castrated = c.Boolean(nullable: false),
                        Gender = c.String(),
                    })
                .PrimaryKey(t => t.DogID)
                .ForeignKey("dbo.Givers", t => t.GID, cascadeDelete: true)
                .Index(t => t.GID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Age = c.Double(nullable: false),
                        Gender = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Givers", "UID", "dbo.Users");
            DropForeignKey("dbo.Dogs", "GID", "dbo.Givers");
            DropForeignKey("dbo.Comments", "GiverID", "dbo.Givers");
            DropIndex("dbo.Dogs", new[] { "GID" });
            DropIndex("dbo.Givers", new[] { "UID" });
            DropIndex("dbo.Comments", new[] { "GiverID" });
            DropTable("dbo.Users");
            DropTable("dbo.Dogs");
            DropTable("dbo.Givers");
            DropTable("dbo.Comments");
        }
    }
}
