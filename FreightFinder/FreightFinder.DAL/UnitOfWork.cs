using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Domain;
using FreightFinder.Core.IDAL;
using FreightFinder.Core.IoC;
using FreightFinder.DAL.Repository;

namespace FreightFinder.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FreightFinderDbContext _context;

        private static UnitOfWork _instance;

        public static UnitOfWork Instance()
        {
            if (_instance == null)
            {
                _instance = new UnitOfWork();
            }

            return _instance;
        }

        public UnitOfWork()
        {
            if (_context == null)
            {
                _context = new FreightFinderDbContext();
            }

            CompanyRepository = new CompanyRepository(_context);
            CountryRepository = new CountryRepository(_context);
            CityRepository = new CityRepository(_context);
            CountyRepository = new CountyRepository(_context);
            AddressRepository = new AddressRepository(_context);
            CompanyTypeRepository = new CompanyTypeRepositoryRepository(_context);
            TransportationCompanyRepository = new TransportationCompanyRepository(_context);
            UserRepository = new UserRepository(_context);
            Repository = new Repository<object>(_context);
            LocationRepository = new LocationRepository(_context);
            DriverLocationRepository = new DriverLocationRepository(_context);
            VehicleRepository = new VehicleRepository(_context);
            VehicleBrandRepository= new VehicleBrandRepository(_context);
            VehicleModelRepository = new VehicleModelRepository(_context);
            ColourRepository = new ColourRepository(_context);
            FreightRepository = new FreightRepository(_context);
            OfferToFreightRepository = new OfferToFreightRepository(_context);
            JobOfferToDriverRepository = new JobOfferToDriverRepository(_context);
            CredentialsRepository = new CredentialsRepository(_context);

        }

        public ICompanyRepository CompanyRepository { get; private set; }
        public ICountryRepository CountryRepository { get; private set; }
        public ICityRepository CityRepository { get; private set; }
        public ICountyRepository CountyRepository { get; private set; }
        public IAddressRepository AddressRepository { get; private set; }
        public ICompanyTypeRepository CompanyTypeRepository { get; private set; }
        public ITransportationCompanyRepository TransportationCompanyRepository{ get; private set; }
        public IRepository<object> Repository { get; private set; }
        public IUserRepository UserRepository { get; private set; }
        public ILocationRepository LocationRepository { get; private set; }
        public IDriverLocationRepository DriverLocationRepository { get; private set; }
        public IVehicleRepository VehicleRepository { get; private set; }
        public IVehicleBrandRepository VehicleBrandRepository  { get; private set; }
        public IVehicleModelRepository VehicleModelRepository { get; private set; }
        public IColourRepository ColourRepository { get; private set; }
        public IFreightRepository FreightRepository { get; private set; }
        public IOfferToFreightRepository OfferToFreightRepository { get; private set; }
        public IJobOfferToDriverRepository JobOfferToDriverRepository { get; private set; }
        public ICredentialsRepository CredentialsRepository { get; private set; }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
