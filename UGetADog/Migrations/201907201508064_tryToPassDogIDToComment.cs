namespace UGetADog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tryToPassDogIDToComment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "DogName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "DogName", c => c.String(nullable: false));
        }
    }
}
