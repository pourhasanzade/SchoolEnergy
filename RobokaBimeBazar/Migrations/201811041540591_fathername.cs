namespace RobokaBimeBazar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fathername : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfo", "BirthDate", c => c.String(maxLength: 20));
            AddColumn("dbo.UserInfo", "FatherName", c => c.String(maxLength: 25));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInfo", "FatherName");
            DropColumn("dbo.UserInfo", "BirthDate");
        }
    }
}
