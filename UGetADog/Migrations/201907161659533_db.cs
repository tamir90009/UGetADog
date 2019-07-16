namespace UGetADog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Gender", c => c.String(nullable: false));
            DropColumn("dbo.Users", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Address", c => c.String(nullable: false));
            DropColumn("dbo.Users", "Gender");
            DropColumn("dbo.Users", "Age");
        }
    }
}
