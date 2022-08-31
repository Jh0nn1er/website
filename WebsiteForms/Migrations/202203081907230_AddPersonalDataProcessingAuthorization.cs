namespace WebsiteForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPersonalDataProcessingAuthorization : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "PersonalDataProcessingAuthorization", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Requests", "PersonalDataProcessingAuthorization");
        }
    }
}
