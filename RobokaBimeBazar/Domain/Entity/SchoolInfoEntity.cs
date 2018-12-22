using System.Data.Entity.ModelConfiguration;

namespace RobokaBimeBazar.Domain.Entity
{
    public class SchoolEntity : BaseEntity
    {
        public string Name { get; set; }
        public long? ProvinceId { get; set; }
        public long? CityId { get; set; }
        public string GasSubscriptionNo
    }

    public class SchoolEntityConfiguration : EntityTypeConfiguration<SchoolEntity>
    {
        public SchoolEntityConfiguration()
        {
            Property(x => x.Name).HasMaxLength(100);

            ToTable("Schools");
        }
    }
}