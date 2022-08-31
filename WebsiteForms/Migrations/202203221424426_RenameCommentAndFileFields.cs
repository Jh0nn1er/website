namespace WebsiteForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameCommentAndFileFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "FileURL", c => c.String(maxLength: 2048));
            AddColumn("dbo.Requests", "Comment", c => c.String(maxLength: 50));
            AlterColumn("dbo.Requests", "Identifier", c => c.String(maxLength: 13));
            DropColumn("dbo.Requests", "PolicyPDFURL");
            DropColumn("dbo.Requests", "PQRComment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requests", "PQRComment", c => c.String(maxLength: 50));
            AddColumn("dbo.Requests", "PolicyPDFURL", c => c.String(maxLength: 2048));
            AlterColumn("dbo.Requests", "Identifier", c => c.String(nullable: false, maxLength: 13));
            DropColumn("dbo.Requests", "Comment");
            DropColumn("dbo.Requests", "FileURL");
        }
    }
}
