namespace WebsiteForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixEconomicActivity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Requests", "EconomicActivity", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Requests", "EconomicActivity", c => c.String(maxLength: 50));
        }
    }
}
