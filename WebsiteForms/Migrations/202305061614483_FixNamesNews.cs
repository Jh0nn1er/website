namespace WebsiteForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixNamesNews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "Title", c => c.String());
            AddColumn("dbo.News", "Description", c => c.String());
            AddColumn("dbo.News", "Url", c => c.String());
            AddColumn("dbo.News", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.News", "State", c => c.Boolean(nullable: false));
            DropColumn("dbo.News", "newTitle");
            DropColumn("dbo.News", "newDescription");
            DropColumn("dbo.News", "newUrl");
            DropColumn("dbo.News", "newDate");
            DropColumn("dbo.News", "newState");
        }
        
        public override void Down()
        {
            AddColumn("dbo.News", "newState", c => c.Boolean(nullable: false));
            AddColumn("dbo.News", "newDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.News", "newUrl", c => c.String());
            AddColumn("dbo.News", "newDescription", c => c.String());
            AddColumn("dbo.News", "newTitle", c => c.String());
            DropColumn("dbo.News", "State");
            DropColumn("dbo.News", "Date");
            DropColumn("dbo.News", "Url");
            DropColumn("dbo.News", "Description");
            DropColumn("dbo.News", "Title");
        }
    }
}
