namespace UGetADog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migratinAfterSenderNae : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Sendername", c => c.String(nullable: false));
            DropColumn("dbo.Comments", "Username");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "Username", c => c.String(nullable: false));
            DropColumn("dbo.Comments", "Sendername");
        }
    }
}
