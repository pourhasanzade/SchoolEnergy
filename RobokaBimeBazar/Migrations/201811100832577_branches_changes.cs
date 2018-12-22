namespace RobokaBimeBazar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class branches_changes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Branches", "Address", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Branches", "Address", c => c.String(maxLength: 50));
        }
    }
}
