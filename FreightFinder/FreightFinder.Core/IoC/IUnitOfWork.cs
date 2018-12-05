using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Domain;
using FreightFinder.Core.IDAL;

namespace FreightFinder.Core.IoC
{
    public interface IUnitOfWork : IDisposable
    {
        ICompanyRepository CompanyRepository { get; }
        ICountryRepository CountryRepository { get; }
        ICityRepository CityRepository { get; }
        ICountyRepository CountyRepository { get; }
        IAddressRepository AddressRepository { get; }
        ICompanyTypeRepository CompanyTypeRepository { get; }
        ITransportationCompanyRepository TransportationCompanyRepository { get; }
        IUserRepository UserRepository { get; }
        IRepository<Object> Repository { get; }
        ILocationRepository LocationRepository { get; }
        IDriverLocationRepository DriverLocationRepository { get; }
        IVehicleRepository VehicleRepository { get; }
        IVehicleBrandRepository VehicleBrandRepository { get; }
        IVehicleModelRepository VehicleModelRepository { get; }
        IColourRepository ColourRepository { get; }
        IFreightRepository FreightRepository { get; }
        IOfferToFreightRepository OfferToFreightRepository { get; }
        IJobOfferToDriverRepository JobOfferToDriverRepository { get; }
        ICredentialsRepository CredentialsRepository { get; }

        int Complete();
    }
}
