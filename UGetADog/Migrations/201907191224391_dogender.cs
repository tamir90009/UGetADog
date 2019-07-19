namespace UGetADog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dogender : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Dogs", "Gender", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dogs", "Gender", c => c.String());
        }
    }
}
