namespace WebsiteForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Configurations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        Description = c.String(),
                        Value = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HabeasDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeleteOfComercialBases = c.Boolean(),
                        DeleteOfCampaignBases = c.Boolean(),
                        DeleteOfEventBases = c.Boolean(),
                        LandLine = c.String(maxLength: 10),
                        Reason = c.String(nullable: false),
                        EmailNotification = c.String(),
                        AddressNotification = c.String(maxLength: 200),
                        CellPhoneNotification = c.String(maxLength: 15),
                        Request_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Requests", t => t.Request_Id)
                .Index(t => t.Request_Id);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 100),
                        DocumentType = c.String(maxLength: 25),
                        Identifier = c.String(maxLength: 13),
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
                        PQRType = c.String(maxLength: 50),
                        Comment = c.String(),
                        PersonalDataProcessingAuthorization = c.Boolean(),
                        Age = c.Short(),
                        Position = c.String(maxLength: 30),
                        LastAcademicLevel = c.String(maxLength: 30),
                        EconomicActivity = c.String(maxLength: 200),
                        SQRType = c.String(maxLength: 200),
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
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JsonData = c.String(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RequestFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestId = c.Int(),
                        FileURL = c.String(maxLength: 2048),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Requests", t => t.RequestId)
                .Index(t => t.RequestId);
            
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
            DropForeignKey("dbo.RequestFiles", "RequestId", "dbo.Requests");
            DropForeignKey("dbo.HabeasDatas", "Request_Id", "dbo.Requests");
            DropForeignKey("dbo.Requests", "RequestType_Id", "dbo.RequestTypes");
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.RequestFiles", new[] { "RequestId" });
            DropIndex("dbo.Requests", new[] { "RequestType_Id" });
            DropIndex("dbo.HabeasDatas", new[] { "Request_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.RequestFiles");
            DropTable("dbo.Logs");
            DropTable("dbo.RequestTypes");
            DropTable("dbo.Requests");
            DropTable("dbo.HabeasDatas");
            DropTable("dbo.Configurations");
        }
    }
}
