namespace UGetADog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class role : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Role", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Role", c => c.Int(nullable: false));
        }
    }
}
