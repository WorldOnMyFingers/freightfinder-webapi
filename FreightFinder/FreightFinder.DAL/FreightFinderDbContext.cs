namespace FreightFinder.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using FreightFinder.Core.Domain;

    public partial class FreightFinderDbContext : DbContext
    {
        public FreightFinderDbContext()
            : base("name=FreightFinderDbContext")
        {
            Database.SetInitializer<FreightFinderDbContext>(null);
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CompanyConfiguration());
            modelBuilder.Configurations.Add(new CompanyTypeConfiguration());
            modelBuilder.Configurations.Add(new AddressConfiguration());
            modelBuilder.Configurations.Add(new CountryConfiguration());
            modelBuilder.Configurations.Add(new CityConfiguration());
            modelBuilder.Configurations.Add(new CountyConfiguration());
            modelBuilder.Configurations.Add(new StateConfiguration());
            modelBuilder.Configurations.Add(new TransportationCompanyConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new CredentialsConfiguration());
            modelBuilder.Configurations.Add(new LocationConfiguration());
            modelBuilder.Configurations.Add(new LocationDriverConfiguration());
            modelBuilder.Configurations.Add(new VehicleConfiguration());
            modelBuilder.Configurations.Add(new VehicleBrandConfiguration());
            modelBuilder.Configurations.Add(new VehicleModelConfiguration());
            modelBuilder.Configurations.Add(new ColourConfiguration());
            modelBuilder.Configurations.Add(new FreightConfiguration());
            modelBuilder.Configurations.Add(new OfferToFreightConfiguration());
            modelBuilder.Configurations.Add(new JobOfferToDriverConfiguration());
        }
    }
}
