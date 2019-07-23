namespace UGetADog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mergeTamirBreanchMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dogs", "ID", "dbo.Givers");
            RenameColumn(table: "dbo.Dogs", name: "ID", newName: "GID");
            RenameIndex(table: "dbo.Dogs", name: "IX_ID", newName: "IX_GID");
            DropPrimaryKey("dbo.Dogs");
            AlterColumn("dbo.Dogs", "DogID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Dogs", "DogID");
            AddForeignKey("dbo.Dogs", "GID", "dbo.Givers", "GiverID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dogs", "GID", "dbo.Givers");
            DropPrimaryKey("dbo.Dogs");
            AlterColumn("dbo.Dogs", "DogID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Dogs", "ID");
            RenameIndex(table: "dbo.Dogs", name: "IX_GID", newName: "IX_ID");
            RenameColumn(table: "dbo.Dogs", name: "GID", newName: "ID");
            AddForeignKey("dbo.Dogs", "ID", "dbo.Givers", "GiverID");
        }
    }
}
