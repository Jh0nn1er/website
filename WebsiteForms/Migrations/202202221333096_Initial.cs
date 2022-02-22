namespace WebsiteForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 100),
                        Identifier = c.String(nullable: false, maxLength: 13),
                        PhoneNumber = c.String(nullable: false, maxLength: 15),
                        Email = c.String(nullable: false),
                        Credit = c.String(maxLength: 10),
                        ModificationType = c.String(maxLength: 50),
                        Term = c.Int(),
                        NewPaymentDate = c.DateTime(),
                        LossOccuranceType = c.String(maxLength: 50),
                        VehicleChanges = c.String(maxLength: 50),
                        LicensePlate = c.String(maxLength: 6),
                        PaymentDate = c.DateTime(),
                        ProcedureType = c.String(maxLength: 50),
                        PolicyPDFURL = c.String(maxLength: 2048),
                        PQRType = c.String(maxLength: 50),
                        PQRComment = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(nullable: false),
                        RequestType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RequestTypes", t => t.RequestType_Id)
                .Index(t => t.RequestType_Id);
            
            CreateTable(
                "dbo.RequestTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "RequestType_Id", "dbo.RequestTypes");
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.Requests", new[] { "RequestType_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.RequestTypes");
            DropTable("dbo.Requests");
        }
    }
}
