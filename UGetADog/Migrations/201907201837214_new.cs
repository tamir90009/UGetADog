namespace UGetADog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Dogs", "Size", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dogs", "Size", c => c.String());
        }
    }
}
