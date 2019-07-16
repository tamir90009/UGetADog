namespace UGetADog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Givers", "Address", c => c.String());
            AddColumn("dbo.Givers", "Latitude", c => c.Double(nullable: false));
            AddColumn("dbo.Givers", "Longtitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Givers", "Longtitude");
            DropColumn("dbo.Givers", "Latitude");
            DropColumn("dbo.Givers", "Address");
        }
    }
}
