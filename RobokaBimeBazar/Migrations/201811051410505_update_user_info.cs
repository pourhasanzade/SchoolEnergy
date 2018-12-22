namespace RobokaBimeBazar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_user_info : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfo", "UId", c => c.String());
            AddColumn("dbo.UserInfo", "Submitted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.UserInfo", "BirthDate", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserInfo", "BirthDate", c => c.String(maxLength: 20));
            DropColumn("dbo.UserInfo", "Submitted");
            DropColumn("dbo.UserInfo", "UId");
        }
    }
}
