namespace RobokaBimeBazar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_phone_number : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfo", "DeliveryPhone", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInfo", "DeliveryPhone");
        }
    }
}
