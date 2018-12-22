using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace RobokaBimeBazar.Domain.Entity
{
    public class ProvinceEntity : BaseEntity
    {
        public string ProvinceName { get; set; }
        public string ProvinceNameFa { get; set; }
        public ICollection<CityEntity> CityCollection { get; set; }
    }

    public class ProvinceEntityConfiguration : EntityTypeConfiguration<ProvinceEntity>
    {
        public ProvinceEntityConfiguration()
        {
            Property(x => x.ProvinceName).HasMaxLength(50);
            Property(x => x.ProvinceNameFa).HasMaxLength(50);

            HasIndex(x => x.ProvinceNameFa).IsUnique(false);
            HasIndex(x => x.ProvinceName).IsUnique(false);

            ToTable("Provinces");
        }
    }
}