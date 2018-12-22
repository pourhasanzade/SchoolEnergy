namespace RobokaBimeBazar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class terminateStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfo", "Terminated", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInfo", "Terminated");
        }
    }
}
