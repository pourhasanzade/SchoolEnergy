namespace RobokaBimeBazar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class branches : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Orders", new[] { "ChatId" });
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BranchId = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                        Address = c.String(maxLength: 50),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.UserInfo", "Mobile", c => c.String(maxLength: 11));
            AddColumn("dbo.UserInfo", "TrackingCode", c => c.String(maxLength: 20));
            AddColumn("dbo.UserInfo", "LastUpdatedPriceTime", c => c.DateTime());
            AddColumn("dbo.UserInfo", "Price", c => c.String(maxLength: 10));
            AddColumn("dbo.UserInfo", "BirthCertificateSecondPageImg", c => c.String(maxLength: 100));
            AddColumn("dbo.UserInfo", "GaurdianNationalCode", c => c.String(maxLength: 100));
            AddColumn("dbo.UserInfo", "GaurdianBcFirstPageImg", c => c.String(maxLength: 100));
            AddColumn("dbo.UserInfo", "GaurdianBcSpousePageImg", c => c.String(maxLength: 100));
            AlterColumn("dbo.Orders", "ChatId", c => c.String(maxLength: 250));
            AlterColumn("dbo.Orders", "Type", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "SettleStatus", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "OrderStatus", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "OrderPrepareData");
            DropColumn("dbo.Orders", "OrderCompleteData");
            DropColumn("dbo.UserInfo", "GaurdianIdCardImg");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserInfo", "GaurdianIdCardImg", c => c.String(maxLength: 100));
            AddColumn("dbo.Orders", "OrderCompleteData", c => c.String());
            AddColumn("dbo.Orders", "OrderPrepareData", c => c.String());
            AlterColumn("dbo.Orders", "OrderStatus", c => c.Int());
            AlterColumn("dbo.Orders", "SettleStatus", c => c.Int());
            AlterColumn("dbo.Orders", "Status", c => c.Int());
            AlterColumn("dbo.Orders", "Type", c => c.Int());
            AlterColumn("dbo.Orders", "ChatId", c => c.String(maxLength: 50));
            DropColumn("dbo.UserInfo", "GaurdianBcSpousePageImg");
            DropColumn("dbo.UserInfo", "GaurdianBcFirstPageImg");
            DropColumn("dbo.UserInfo", "GaurdianNationalCode");
            DropColumn("dbo.UserInfo", "BirthCertificateSecondPageImg");
            DropColumn("dbo.UserInfo", "Price");
            DropColumn("dbo.UserInfo", "LastUpdatedPriceTime");
            DropColumn("dbo.UserInfo", "TrackingCode");
            DropColumn("dbo.UserInfo", "Mobile");
            DropTable("dbo.Branches");
            CreateIndex("dbo.Orders", "ChatId");
        }
    }
}
