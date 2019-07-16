namespace UGetADog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dubleage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Age", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Age", c => c.Int(nullable: false));
        }
    }
}
