namespace WebsiteForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAgeInRequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "Age", c => c.Short());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Requests", "Age");
        }
    }
}
