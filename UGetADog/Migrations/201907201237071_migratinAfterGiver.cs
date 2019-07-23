namespace UGetADog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migratinAfterGiver : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "DogName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "DogName");
        }
    }
}
