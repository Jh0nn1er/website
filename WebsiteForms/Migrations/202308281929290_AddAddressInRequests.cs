namespace WebsiteForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressInRequests : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Requests", "Address");
        }
    }
}
