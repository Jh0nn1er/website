namespace WebsiteForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderColumnInInvestorTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "Order", c => c.Int(nullable: false));
            AddColumn("dbo.InformationGroups", "Order", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InformationGroups", "Order");
            DropColumn("dbo.Documents", "Order");
        }
    }
}
