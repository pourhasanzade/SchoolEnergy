namespace RobokaBimeBazar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class order_uid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "UId", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "UId");
        }
    }
}
