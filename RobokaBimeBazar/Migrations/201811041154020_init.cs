namespace RobokaBimeBazar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buttons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Text = c.String(maxLength: 50),
                        Type = c.Int(nullable: false),
                        ViewType = c.Int(nullable: false),
                        ImageUrl = c.String(maxLength: 250),
                        Row = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                        Data = c.String(maxLength: 500),
                        BehaviourType = c.Int(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        NameFa = c.String(maxLength: 50),
                        PhonePrefix = c.String(maxLength: 10),
                        ProvinceId = c.Int(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId, cascadeDelete: true)
                .Index(t => t.NameFa)
                .Index(t => t.ProvinceId);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProvinceName = c.String(maxLength: 50),
                        ProvinceNameFa = c.String(maxLength: 50),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.ProvinceName)
                .Index(t => t.ProvinceNameFa);
            
            CreateTable(
                "dbo.Configs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastMessageId = c.String(maxLength: 200),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExceptionLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChatId = c.String(maxLength: 250),
                        Title = c.String(maxLength: 250),
                        Exception = c.String(),
                        WebException = c.String(),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChatId = c.String(maxLength: 250),
                        Input = c.String(),
                        ButtonId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.ChatId, unique: true);
            
            CreateTable(
                "dbo.UserInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChatId = c.String(maxLength: 20),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        NationalCode = c.String(maxLength: 10),
                        PolicyId = c.String(maxLength: 10),
                        InsuranceStatus = c.Int(),
                        SocialSecurityServiceType = c.Int(),
                        SocialSecurityBranchId = c.Int(),
                        Gender = c.Int(),
                        InPersonDelivery = c.Boolean(),
                        NumOfRemainingPages = c.Int(),
                        PersonalPhotoImg = c.String(),
                        BirthCertificateFirstPageImg = c.String(),
                        NationalCardImg = c.String(),
                        NationalCardBackImg = c.String(),
                        InsuranceBookletCoverImg = c.String(),
                        LastUsedPageImg = c.String(),
                        EducationCertificationImg = c.String(),
                        DeliveryCity = c.String(),
                        DeliveryProvince = c.String(),
                        DeliveryAddress = c.String(),
                        DeliveryPostalCode = c.String(),
                        DeliveryTime = c.String(),
                        PickupCity = c.String(),
                        PickupProvince = c.String(),
                        PickupAddress = c.String(),
                        PickupPostalCode = c.String(),
                        PickupStartTime = c.String(),
                        PickupEndTime = c.String(),
                        GaurdianPolicyId = c.String(),
                        GaurdianDependencyType = c.Int(),
                        GaurdianBirthDate = c.String(),
                        GaurdianSocialSecurityBranchId = c.Int(),
                        GaurdianStatus = c.Int(),
                        SpouseLifeStatus = c.Int(),
                        GaurdianIdCardImg = c.String(),
                        GaurdianFamilyImg = c.String(),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.ChatId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cities", "ProvinceId", "dbo.Provinces");
            DropIndex("dbo.UserInfo", new[] { "ChatId" });
            DropIndex("dbo.UserData", new[] { "ChatId" });
            DropIndex("dbo.Provinces", new[] { "ProvinceNameFa" });
            DropIndex("dbo.Provinces", new[] { "ProvinceName" });
            DropIndex("dbo.Cities", new[] { "ProvinceId" });
            DropIndex("dbo.Cities", new[] { "NameFa" });
            DropIndex("dbo.Buttons", new[] { "StateId" });
            DropTable("dbo.UserInfo");
            DropTable("dbo.UserData");
            DropTable("dbo.ExceptionLogs");
            DropTable("dbo.Configs");
            DropTable("dbo.Provinces");
            DropTable("dbo.Cities");
            DropTable("dbo.Buttons");
        }
    }
}
