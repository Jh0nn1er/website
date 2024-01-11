namespace WebsiteForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixNews : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.News", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.News", "Date", c => c.DateTime(nullable: false));
        }
    }
}
