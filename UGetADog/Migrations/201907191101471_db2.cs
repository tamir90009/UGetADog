namespace UGetADog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Givers", "Address", c => c.String());
            AddColumn("dbo.Givers", "Latitude", c => c.Double(nullable: false));
            AddColumn("dbo.Givers", "Longtitude", c => c.Double(nullable: false));
            AddColumn("dbo.Users", "Age", c => c.Double(nullable: false));
            AddColumn("dbo.Users", "Gender", c => c.String(nullable: false));
            DropColumn("dbo.Users", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Address", c => c.String(nullable: false));
            DropColumn("dbo.Users", "Gender");
            DropColumn("dbo.Users", "Age");
            DropColumn("dbo.Givers", "Longtitude");
            DropColumn("dbo.Givers", "Latitude");
            DropColumn("dbo.Givers", "Address");
        }
    }
}
