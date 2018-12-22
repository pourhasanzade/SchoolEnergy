namespace RobokaBimeBazar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class order : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChatId = c.String(maxLength: 50),
                        OrderPrepareData = c.String(),
                        OrderCompleteData = c.String(),
                        PaymentToken = c.String(maxLength: 250),
                        Type = c.Int(),
                        Status = c.Int(),
                        SettleStatus = c.Int(),
                        OrderStatus = c.Int(),
                        Amount = c.String(maxLength: 250),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.ChatId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Orders", new[] { "ChatId" });
            DropTable("dbo.Orders");
        }
    }
}
