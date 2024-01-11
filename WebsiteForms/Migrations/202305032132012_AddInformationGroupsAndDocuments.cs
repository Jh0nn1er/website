namespace WebsiteForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInformationGroupsAndDocuments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        InformationGroupId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InformationGroups", t => t.InformationGroupId, cascadeDelete: true)
                .Index(t => t.InformationGroupId);
            
            CreateTable(
                "dbo.InformationGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        ParentInformationGroupId = c.Int(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InformationGroups", t => t.ParentInformationGroupId)
                .Index(t => t.ParentInformationGroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InformationGroups", "ParentInformationGroupId", "dbo.InformationGroups");
            DropForeignKey("dbo.Documents", "InformationGroupId", "dbo.InformationGroups");
            DropIndex("dbo.InformationGroups", new[] { "ParentInformationGroupId" });
            DropIndex("dbo.Documents", new[] { "InformationGroupId" });
            DropTable("dbo.InformationGroups");
            DropTable("dbo.Documents");
        }
    }
}
