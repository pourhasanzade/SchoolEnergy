namespace RobokaBimeBazar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfo", "InsuredStatus", c => c.Int());
            AlterColumn("dbo.UserInfo", "PersonalPhotoImg", c => c.String(maxLength: 100));
            AlterColumn("dbo.UserInfo", "BirthCertificateFirstPageImg", c => c.String(maxLength: 100));
            AlterColumn("dbo.UserInfo", "NationalCardImg", c => c.String(maxLength: 100));
            AlterColumn("dbo.UserInfo", "NationalCardBackImg", c => c.String(maxLength: 100));
            AlterColumn("dbo.UserInfo", "InsuranceBookletCoverImg", c => c.String(maxLength: 100));
            AlterColumn("dbo.UserInfo", "LastUsedPageImg", c => c.String(maxLength: 100));
            AlterColumn("dbo.UserInfo", "EducationCertificationImg", c => c.String(maxLength: 100));
            AlterColumn("dbo.UserInfo", "DeliveryCity", c => c.String(maxLength: 20));
            AlterColumn("dbo.UserInfo", "DeliveryProvince", c => c.String(maxLength: 20));
            AlterColumn("dbo.UserInfo", "DeliveryAddress", c => c.String(maxLength: 250));
            AlterColumn("dbo.UserInfo", "DeliveryPostalCode", c => c.String(maxLength: 10));
            AlterColumn("dbo.UserInfo", "DeliveryTime", c => c.String(maxLength: 100));
            AlterColumn("dbo.UserInfo", "PickupCity", c => c.String(maxLength: 20));
            AlterColumn("dbo.UserInfo", "PickupProvince", c => c.String(maxLength: 20));
            AlterColumn("dbo.UserInfo", "PickupAddress", c => c.String(maxLength: 250));
            AlterColumn("dbo.UserInfo", "PickupPostalCode", c => c.String(maxLength: 10));
            AlterColumn("dbo.UserInfo", "PickupStartTime", c => c.String(maxLength: 100));
            AlterColumn("dbo.UserInfo", "PickupEndTime", c => c.String(maxLength: 100));
            AlterColumn("dbo.UserInfo", "GaurdianPolicyId", c => c.String(maxLength: 10));
            AlterColumn("dbo.UserInfo", "GaurdianBirthDate", c => c.String(maxLength: 20));
            AlterColumn("dbo.UserInfo", "GaurdianIdCardImg", c => c.String(maxLength: 100));
            AlterColumn("dbo.UserInfo", "GaurdianFamilyImg", c => c.String(maxLength: 100));
            DropColumn("dbo.UserInfo", "InsuranceStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserInfo", "InsuranceStatus", c => c.Int());
            AlterColumn("dbo.UserInfo", "GaurdianFamilyImg", c => c.String());
            AlterColumn("dbo.UserInfo", "GaurdianIdCardImg", c => c.String());
            AlterColumn("dbo.UserInfo", "GaurdianBirthDate", c => c.String());
            AlterColumn("dbo.UserInfo", "GaurdianPolicyId", c => c.String());
            AlterColumn("dbo.UserInfo", "PickupEndTime", c => c.String());
            AlterColumn("dbo.UserInfo", "PickupStartTime", c => c.String());
            AlterColumn("dbo.UserInfo", "PickupPostalCode", c => c.String());
            AlterColumn("dbo.UserInfo", "PickupAddress", c => c.String());
            AlterColumn("dbo.UserInfo", "PickupProvince", c => c.String());
            AlterColumn("dbo.UserInfo", "PickupCity", c => c.String());
            AlterColumn("dbo.UserInfo", "DeliveryTime", c => c.String());
            AlterColumn("dbo.UserInfo", "DeliveryPostalCode", c => c.String());
            AlterColumn("dbo.UserInfo", "DeliveryAddress", c => c.String());
            AlterColumn("dbo.UserInfo", "DeliveryProvince", c => c.String());
            AlterColumn("dbo.UserInfo", "DeliveryCity", c => c.String());
            AlterColumn("dbo.UserInfo", "EducationCertificationImg", c => c.String());
            AlterColumn("dbo.UserInfo", "LastUsedPageImg", c => c.String());
            AlterColumn("dbo.UserInfo", "InsuranceBookletCoverImg", c => c.String());
            AlterColumn("dbo.UserInfo", "NationalCardBackImg", c => c.String());
            AlterColumn("dbo.UserInfo", "NationalCardImg", c => c.String());
            AlterColumn("dbo.UserInfo", "BirthCertificateFirstPageImg", c => c.String());
            AlterColumn("dbo.UserInfo", "PersonalPhotoImg", c => c.String());
            DropColumn("dbo.UserInfo", "InsuredStatus");
        }
    }
}
