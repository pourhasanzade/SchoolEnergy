using System.Data.Entity;
using RobokaBimeBazar.Domain.Entity;

namespace RobokaBimeBazar.DAL
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<ButtonEntity> Buttons { get; set; }
        public DbSet<UserDataEntity> UserData { get; set; }
        public DbSet<ConfigEntity> Configs { get; set; }
        public DbSet<CityEntity> Cities { get; set; }
        public DbSet<ProvinceEntity> Provinces { get; set; }
        public DbSet<ExceptionLogEntity> ExceptionLogs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ButtonEntityConfiguration());
            modelBuilder.Configurations.Add(new UserDataEntityConfiguration());
            modelBuilder.Configurations.Add(new ConfigEntityConfiguration());
            modelBuilder.Configurations.Add(new CityEntityConfiguration());
            modelBuilder.Configurations.Add(new ProvinceEntityConfiguration());
            modelBuilder.Configurations.Add(new ExceptionLogEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}