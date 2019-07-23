namespace UGetADog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "GiverID", "dbo.Givers");
            DropIndex("dbo.Comments", new[] { "GiverID" });
            DropTable("dbo.Comments");
        }
    }
}
