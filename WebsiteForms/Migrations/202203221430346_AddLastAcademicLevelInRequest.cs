namespace WebsiteForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLastAcademicLevelInRequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "LastAcademicLevel", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Requests", "LastAcademicLevel");
        }
    }
}
