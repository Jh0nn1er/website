namespace WebsiteForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixSQR : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "SQRType", c => c.String(maxLength: 15));
            AlterColumn("dbo.HabeasDatas", "LandLine", c => c.String(maxLength: 10));
            DropColumn("dbo.HabeasDatas", "SQRType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HabeasDatas", "SQRType", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.HabeasDatas", "LandLine", c => c.String(nullable: false, maxLength: 10));
            DropColumn("dbo.Requests", "SQRType");
        }
    }
}
