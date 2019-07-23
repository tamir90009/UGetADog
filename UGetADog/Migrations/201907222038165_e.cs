namespace UGetADog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class e : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dogs", "file", c => c.String(nullable: false));
            DropColumn("dbo.Dogs", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dogs", "Image", c => c.String(maxLength: 30));
            DropColumn("dbo.Dogs", "file");
        }
    }
}
