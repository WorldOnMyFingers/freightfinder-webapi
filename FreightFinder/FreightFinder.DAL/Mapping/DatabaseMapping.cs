using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Domain;

namespace FreightFinder.DAL
{
    public class CompanyConfiguration : EntityTypeConfiguration<Company>
    {
        public CompanyConfiguration()
        {
            HasKey(c => c.Id);
            Property(c => c.CompanyName).HasColumnType("varchar").HasColumnName("Company_Name").IsRequired();
            Property(c => c.Email).HasColumnType("varchar").HasColumnName("Email").IsOptional();
            Property(e => e.Telephone).HasColumnType("varchar").HasColumnName("Telephone").IsOptional();
            Property(e => e.TaxNumber).HasColumnType("varchar").HasColumnName("Tax_Number").IsOptional();
            Property(e => e.TaxOffice).HasColumnType("varchar").HasColumnName("Tax_Office").IsOptional();
            Property(c => c.IsActive).HasColumnType("bit").HasColumnName("IsActive").IsRequired();
            Property(c => c.AddressId).HasColumnType("int").HasColumnName("Address_Id").IsRequired();
            Property(c => c.MembershipDate).HasColumnType("datetime").HasColumnName("Membership_Date").IsRequired();
            Property(c => c.CompanyType).HasColumnType("int").HasColumnName("Company_Type_Code").IsRequired();
            HasRequired(c => c.Address);


        }
    }

    public class CompanyTypeConfiguration : EntityTypeConfiguration<CompanyType>
    {
        public CompanyTypeConfiguration()
        {
            HasKey(c => c.Code);
            Property(c => c.CompanyTypeName).HasColumnType("varchar").HasColumnName("Company_Type_Name").IsRequired();
            Property(c => c.IsActive).HasColumnType("bit").HasColumnName("IsActive").IsRequired();

        }

    }

    public class AddressConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            HasKey(c => c.Id);
            Property(c => c.AddressLine).HasColumnType("varchar").HasColumnName("Address_Line").IsRequired();
            Property(c => c.DateCreated).HasColumnType("datetime").HasColumnName("Date_Created").IsRequired();
            Property(c => c.District).HasColumnType("varchar").HasColumnName("District").IsRequired();
            Property(c => c.Phone).HasColumnType("varchar").HasColumnName("Phone").IsRequired();
            Property(c => c.IsActive).HasColumnType("bit").HasColumnName("IsActive").IsRequired();
            HasRequired(c => c.Country);
            HasRequired(c => c.City);
            HasRequired(c => c.County);

        }
    }

    public class CountryConfiguration : EntityTypeConfiguration<Country>
    {
        public CountryConfiguration()
        {
            HasKey(c => c.Id);
            Property(c => c.CountryName).HasColumnType("varchar").HasColumnName("Country_Name").IsRequired();
            Property(c => c.IsActive).HasColumnType("bit").HasColumnName("IsActive").IsRequired();

        }
    }

    public class CountyConfiguration : EntityTypeConfiguration<County>
    {
        public CountyConfiguration()
        {
            HasKey(c => c.Id);
            Property(c => c.CountyName).HasColumnType("varchar").HasColumnName("County_Name").IsRequired();
            Property(c => c.IsActive).HasColumnType("bit").HasColumnName("IsActive").IsRequired();
            HasRequired(c => c.City);
            HasOptional(c => c.Coordinates);
        }
    }

    public class CityConfiguration : EntityTypeConfiguration<City>
    {
        public CityConfiguration()
        {
            HasKey(c => c.Id);
            Property(c => c.CityName).HasColumnType("varchar").HasColumnName("City_Name").IsRequired();
            Property(c => c.IsActive).HasColumnType("bit").HasColumnName("IsActive").IsRequired();
            HasRequired(c => c.Country);
            HasOptional(c => c.Coordinates);

        }
    }

    public class StateConfiguration : EntityTypeConfiguration<State>
    {
        public StateConfiguration()
        {
            HasKey(c => c.Id);
            Property(c => c.StateName).HasColumnType("varchar").HasColumnName("City_Name").IsRequired();
            Property(c => c.IsActive).HasColumnType("bit").HasColumnName("IsActive").IsRequired();

        }
    }

    public class TransportationCompanyConfiguration : EntityTypeConfiguration<TransportationCompany>
    {
        public TransportationCompanyConfiguration()
        {
            ToTable("Transportation_Company");
            Property(c => c.Balance).HasColumnType("decimal").HasColumnName("Balance").IsRequired();


        }
    }

    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("Users");
            HasKey(x => x.Id);
            Property(c => c.NationalIdentity).HasColumnType("bigint").HasColumnName("National_Identity_Id").IsRequired();
            Property(c => c.UserType).HasColumnType("int").HasColumnName("User_Type_Id").IsRequired();
            Property(c => c.Mobile).HasColumnType("varchar").HasColumnName("Telephone").IsRequired();
            Property(c => c.Name).HasColumnType("varchar").HasColumnName("Name").IsRequired();
            Property(c => c.Surename).HasColumnType("varchar").HasColumnName("Surename").IsRequired();
            Property(c => c.Username).HasColumnType("varchar").HasColumnName("Username").IsRequired();
            Property(c => c.Password).HasColumnType("varchar").HasColumnName("Password").IsRequired();
            Property(c => c.DateOfBirth).HasColumnType("datetime").HasColumnName("Date_Of_Birth").IsRequired();
            Property(c => c.DateCreated).HasColumnType("datetime").HasColumnName("Date_Created").IsRequired();
            Property(c => c.Email).HasColumnType("varchar").HasColumnName("Email").IsRequired();
            Property(c => c.PicturePath).HasColumnType("varchar").HasColumnName("Picture_Path").IsOptional();
            Property(c => c.IsActive).HasColumnType("bit").HasColumnName("Is_Active").IsRequired();
            HasOptional(x => x.Company);
        }
    }

    public class CredentialsConfiguration : EntityTypeConfiguration<Credentials>
    {
        public CredentialsConfiguration()
        {
            ToTable("AspNetUsers");
            HasKey(x => x.Id);
            Property(c => c.Email).HasColumnType("varchar").HasColumnName("Email").IsRequired();
            Property(c => c.EmailConfirmed).HasColumnType("bit").HasColumnName("EmailConfirmed").IsRequired();
            Property(c => c.PasswordHash).HasColumnType("varchar").HasColumnName("PasswordHash").IsRequired();
            Property(c => c.PhoneNumber).HasColumnType("varchar").HasColumnName("PhoneNumber").IsOptional();
            Property(c => c.PhoneNumberConfirmed).HasColumnType("bit").HasColumnName("PhoneNumberConfirmed").IsRequired();
            Property(c => c.SecurityStamp).HasColumnType("varchar").HasColumnName("SecurityStamp").IsRequired();
            Property(c => c.TwoFactorEnabled).HasColumnType("bit").HasColumnName("TwoFactorEnabled").IsRequired();
            Property(c => c.UserName).HasColumnType("varchar").HasColumnName("Username").IsRequired();
            Property(c => c.AccessFailedCount).HasColumnType("int").HasColumnName("AccessFailedCount").IsRequired();
            Property(c => c.LockoutEndDateUtc).HasColumnType("datetime").HasColumnName("LockoutEndDateUtc").IsOptional();
            Property(c => c.LockoutEnabled).HasColumnType("bit").HasColumnName("LockoutEnabled").IsRequired();

        }
    }


    public class LocationConfiguration : EntityTypeConfiguration<Location>
    {
        public LocationConfiguration()
        {
            ToTable("Coordinates");
            HasKey(x => x.Id);
            Property(c => c.LocationType).HasColumnType("int").HasColumnName("Coordinates_Type").IsRequired();
            Property(c => c.Latitude).HasColumnType("decimal").HasPrecision(20, 8).HasColumnName("Latitude").IsRequired();
            Property(c => c.Longitude).HasColumnType("decimal").HasPrecision(20,8).HasColumnName("Longitude").IsRequired();
        }
    }

    public class LocationDriverConfiguration : EntityTypeConfiguration<LocationDriver>
    {
        public LocationDriverConfiguration()
        {
            ToTable("Coordinates_Driver");
            Property(c => c.DateCreated).HasColumnType("datetime").HasColumnName("Date_Created").IsRequired();
            Property(c => c.DriverId).HasColumnType("int").HasColumnName("Driver_Id").IsRequired();
            
        }
    }

    //public class LocationFreightConfiguration : EntityTypeConfiguration<LocationFreight>
    //{
    //    public LocationFreightConfiguration()
    //    {
    //        ToTable("Coordinates_Freight");
    //        HasRequired(c => c.Freight);
    //    }
    //}

    //public class LocationCityConfiguration : EntityTypeConfiguration<LocationCity>
    //{
    //    public LocationCityConfiguration()
    //    {
    //        ToTable("Coordinates_City");
    //        HasRequired(c => c.City);
    //    }
    //}

    //public class LocationCountyConfiguration : EntityTypeConfiguration<LocationCounty>
    //{
    //    public LocationCountyConfiguration()
    //    {
    //        ToTable("Coordinates_City");
    //        HasRequired(c => c.County);
    //    }
    //}


    public class VehicleConfiguration : EntityTypeConfiguration<Vehicle>
    {
        public VehicleConfiguration()
        {
            ToTable("Vehicle");
            HasKey(c => c.Id);
            Property(c => c.EngineNumber).HasColumnType("varchar").HasColumnName("Engine_Number").IsRequired();
            Property(c => c.VehicleIdentificationNumber).HasColumnType("varchar").HasColumnName("Vehicle_Identification_Number").IsRequired();
            Property(c => c.PlateNumber).HasColumnType("varchar").HasColumnName("Plate_Number").IsRequired();
            Property(c => c.PicturePath).HasColumnType("varchar").HasColumnName("Picture_Path").IsRequired();
            Property(c => c.IsLoaded).HasColumnType("bit").HasColumnName("Is_Loaded").IsRequired();
            Property(c => c.IsActive).HasColumnType("bit").HasColumnName("Is_Active").IsRequired();
            Property(c => c.DateCreated).HasColumnType("datetime").HasColumnName("Date_Created").IsRequired();
            Property(c => c.VehicleType).HasColumnType("int").HasColumnName("Vehicle_Type_Id").IsRequired();
            Property(c => c.Capacity).HasColumnType("int").HasColumnName("Capacity").IsRequired();
            HasRequired(c => c.Company);
            HasRequired(c => c.Colour);
            HasRequired(c => c.Brand);
            HasRequired(c => c.Model);
            HasOptional(c => c.Driver);
        }
    }

    public class VehicleModelConfiguration : EntityTypeConfiguration<VehicleModel>
    {
        public VehicleModelConfiguration()
        {
            ToTable("Vehicle_Model");
            HasKey(c => c.Code);
            Property(c => c.ModelName).HasColumnType("varchar").HasColumnName("Model_Name").IsRequired();
            Property(c => c.IsActive).HasColumnType("bit").HasColumnName("Is_Active").IsRequired();
            HasRequired(c => c.Brand);
        }
    }

    public class VehicleBrandConfiguration : EntityTypeConfiguration<VehicleBrand>
    {
        public VehicleBrandConfiguration()
        {
            ToTable("Vehicle_Brand");
            HasKey(c => c.Code);
            Property(c => c.BrandName).HasColumnType("varchar").HasColumnName("Brand_Name").IsRequired();
            Property(c => c.IsActive).HasColumnType("bit").HasColumnName("Is_Active").IsRequired();
        }
    }

    public class ColourConfiguration : EntityTypeConfiguration<Colour>
    {
        public ColourConfiguration()
        {
            ToTable("Colour");
            HasKey(c => c.Code);
            Property(c => c.ColourName).HasColumnType("varchar").HasColumnName("Colour_Name").IsRequired();
            Property(c => c.IsActive).HasColumnType("bit").HasColumnName("Is_Active").IsRequired();
        }
    }

    public class FreightConfiguration : EntityTypeConfiguration<Freight>
    {
        public FreightConfiguration()
        {
            ToTable("Freight");
            HasKey(c => c.Id);
            Property(c => c.TotalPrice).HasColumnType("decimal").HasColumnName("Total_Price").IsOptional();
            Property(c => c.UnitPrice).HasColumnType("decimal").HasColumnName("Unit_Price").IsOptional();
            Property(c => c.Description).HasColumnType("varchar").HasColumnName("Description").IsOptional();
            Property(c => c.Weight).HasColumnType("int").HasColumnName("Weight").IsOptional();
            Property(c => c.FreightType).HasColumnType("int").HasColumnName("Freight_Type_Id").IsRequired();
            Property(c => c.DateCreated).HasColumnType("datetime").HasColumnName("Date_Created").IsRequired();
            Property(c => c.LoadingDate).HasColumnType("datetime").HasColumnName("Loading_Date").IsRequired();
            Property(c => c.DeliverByDate).HasColumnType("datetime").HasColumnName("Deliver_By_Date").IsRequired();
            Property(c => c.DateTaken).HasColumnType("datetime").HasColumnName("Date_Taken").IsOptional();
            Property(c => c.IsDelivered).HasColumnType("bit").HasColumnName("Is_Delivered").IsRequired();
            Property(c => c.IsVatIncluded).HasColumnType("bit").HasColumnName("Is_VAT_Included").IsRequired();
            Property(c => c.IsFullVehicleQuantity).HasColumnType("bit").HasColumnName("Is_Full_Vehicle_Quantity").IsRequired();
            Property(c => c.IsActive).HasColumnType("bit").HasColumnName("Is_Active").IsRequired();
            Property(c => c.IsTaken).HasColumnType("bit").HasColumnName("Is_Taken").IsRequired();
            HasOptional(c => c.Address);
            HasOptional(c => c.Location);
            HasRequired(c => c.Company);
            HasOptional(c => c.DestinationAddress);
            HasOptional(c => c.Vehicle);
        }
    }

    public class OfferToFreightConfiguration : EntityTypeConfiguration<OfferToFreight>
    {
        public OfferToFreightConfiguration()
        {
            ToTable("Offer_To_Freight");
            HasKey(c => c.Id);
            Property(c => c.OfferDate).HasColumnType("datetime").HasColumnName("Offer_Date").IsRequired();
            Property(c => c.DateAccepted).HasColumnType("datetime").HasColumnName("Date_Accepted").IsOptional();
            Property(c => c.IsAccepted).HasColumnType("bit").HasColumnName("Is_Accepted").IsRequired();
            Property(c => c.IsActive).HasColumnType("bit").HasColumnName("Is_Active").IsRequired();
            HasRequired(c => c.Freight);
            HasRequired(c => c.Vehicle);
        }
    }

    public class JobOfferToDriverConfiguration : EntityTypeConfiguration<JobOfferToDriver>
    {
        public JobOfferToDriverConfiguration()
        {
            ToTable("Job_Offer_To_Driver");
            HasKey(c => c.Id);
            Property(c => c.DateCreated).HasColumnType("datetime").HasColumnName("Date_Created").IsRequired();
            Property(c => c.DateAccepted).HasColumnType("datetime").HasColumnName("Date_Accepted").IsOptional();
            Property(c => c.IsAccepted).HasColumnType("bit").HasColumnName("Is_Accepted").IsRequired();
            HasRequired(c => c.Vehicle);
            HasRequired(c => c.Driver);
        }
    }
}
