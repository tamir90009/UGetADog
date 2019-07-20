namespace UGetADog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nemigraton : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dogs", "Size", c => c.String());
            AddColumn("dbo.Dogs", "Description", c => c.String());
            AddColumn("dbo.Dogs", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dogs", "Image");
            DropColumn("dbo.Dogs", "Description");
            DropColumn("dbo.Dogs", "Size");
        }
    }
}
