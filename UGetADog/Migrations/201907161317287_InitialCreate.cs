namespace UGetADog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dogs",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        DogID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Age = c.Double(nullable: false),
                        Breed = c.String(nullable: false),
                        Trained = c.Boolean(nullable: false),
                        Immune = c.Boolean(nullable: false),
                        Castrated = c.Boolean(nullable: false),
                        Gender = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Givers", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Givers",
                c => new
                    {
                        GiverID = c.Int(nullable: false, identity: true),
                        UID = c.Int(nullable: false),
                        Phone = c.String(nullable: false),
                        Rating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.GiverID)
                .ForeignKey("dbo.Users", t => t.UID, cascadeDelete: true)
                .Index(t => t.UID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Givers", "UID", "dbo.Users");
            DropForeignKey("dbo.Dogs", "ID", "dbo.Givers");
            DropIndex("dbo.Givers", new[] { "UID" });
            DropIndex("dbo.Dogs", new[] { "ID" });
            DropTable("dbo.Users");
            DropTable("dbo.Givers");
            DropTable("dbo.Dogs");
        }
    }
}
