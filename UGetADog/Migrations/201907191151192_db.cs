namespace UGetADog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dogs", "ID", "dbo.Givers");
            RenameColumn(table: "dbo.Dogs", name: "ID", newName: "GID");
            RenameIndex(table: "dbo.Dogs", name: "IX_ID", newName: "IX_GID");
            DropPrimaryKey("dbo.Dogs");
            AddColumn("dbo.Dogs", "Size", c => c.String());
            AddColumn("dbo.Dogs", "Description", c => c.String());
            AddColumn("dbo.Dogs", "Image", c => c.String());
            AddColumn("dbo.Givers", "Address", c => c.String());
            AddColumn("dbo.Givers", "Latitude", c => c.Double(nullable: false));
            AddColumn("dbo.Givers", "Longtitude", c => c.Double(nullable: false));
            AddColumn("dbo.Users", "Age", c => c.Double(nullable: false));
            AddColumn("dbo.Users", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.Dogs", "DogID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Dogs", "DogID");
            AddForeignKey("dbo.Dogs", "GID", "dbo.Givers", "GiverID", cascadeDelete: true);
            DropColumn("dbo.Users", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Address", c => c.String(nullable: false));
            DropForeignKey("dbo.Dogs", "GID", "dbo.Givers");
            DropPrimaryKey("dbo.Dogs");
            AlterColumn("dbo.Dogs", "DogID", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "Gender");
            DropColumn("dbo.Users", "Age");
            DropColumn("dbo.Givers", "Longtitude");
            DropColumn("dbo.Givers", "Latitude");
            DropColumn("dbo.Givers", "Address");
            DropColumn("dbo.Dogs", "Image");
            DropColumn("dbo.Dogs", "Description");
            DropColumn("dbo.Dogs", "Size");
            AddPrimaryKey("dbo.Dogs", "ID");
            RenameIndex(table: "dbo.Dogs", name: "IX_GID", newName: "IX_ID");
            RenameColumn(table: "dbo.Dogs", name: "GID", newName: "ID");
            AddForeignKey("dbo.Dogs", "ID", "dbo.Givers", "GiverID");
        }
    }
}
