using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace RobokaBimeBazar.Domain.Entity
{
    public class CityEntity : BaseEntity
    {
        public string Name { get; set; }
        public string NameFa { get; set; }
        public string PhonePrefix { get; set; }
        public ProvinceEntity Province { get; set; }
        public int ProvinceId { get; set; }
    }

    public class CityEntityConfiguration : EntityTypeConfiguration<CityEntity>
    {
        public CityEntityConfiguration()
        {
            Property(x => x.Name).HasMaxLength(50);
            Property(x => x.NameFa).HasMaxLength(50);
            Property(x => x.PhonePrefix).HasMaxLength(10);

            HasIndex(x => x.NameFa).IsUnique(false);

            ToTable("Cities");
        }
    }
}