using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core;
using FreightFinder.Core.Domain;
using FreightFinder.Core.Enums;
using FreightFinder.Core.IoC;
using FreightFinder.DAL;
using NSubstitute;

namespace TestFreightFinder
{
    public class Fixtures
    {
        #region Injected Services

        public IUnitOfWork _unitOfWork;
        #endregion

        #region Properties


        public User User { get; set; }
        private Random random = new Random();

        public Fixtures(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Random Getters

        private Double RandomCoordinate
        {
            get { return random.NextDouble(); }
        }

        private DateTime RandomDate
        {
            get
            {
                return new DateTime(random.Next(1950, 2017), random.Next(1, 12), random.Next(1, 30));
            }
        }

        private string RandomEmail
        {
            get { return "email" + random.Next(0, 1000) + "@gmail.com"; }
        }

        private int RandomLongNumber
        {
            get { return random.Next(700000000, 900000000); }
        }

        private string RandomName
        {
            get { return "Person Name " + random.Next(0, 1000); }
        }

        private string RandomSurename
        {
            get { return "Person Surename " + random.Next(0, 1000); }
        }

        private int RandomNumber
        {
            get { return random.Next(7000000, 9000000); }
        }

        private string Path
        {
            get { return "Library/Photos"; }
        }

        #endregion

        #endregion


        public User GetUserFixture()
        {
            var user = new User()
            {
                DateOfBirth = RandomDate,
                Email = RandomEmail,
                Mobile = RandomLongNumber.ToString(),
                Name = RandomName,
                Surename = RandomSurename,
                NationalIdentity = RandomLongNumber,
                Password = RandomNumber.ToString(),
                PicturePath = Path,
                Username = RandomName + RandomSurename,
                UserType = UserType.Driver,
                Id = Guid.NewGuid().ToString(),
                DateCreated = DateTime.Now
            };

            return user;
        }

        public Company GetTransportationCompanyFixture()
        {
            var tCompany = new TransportationCompany();
            tCompany.CompanyName = "Transportation Company " + RandomEmail;
            tCompany.Email = "transportation" + random.Next(1, 100) + "@email.com";
            tCompany.MembershipDate = DateTime.Now;
            tCompany.Telephone = random.Next(1, 999999).ToString();
            tCompany.TaxNumber = random.Next(1, 999999).ToString();
            tCompany.TaxOffice = "Vergi Dairesi " + random.Next(1, 999999);
            tCompany.IsActive = true;
            tCompany.CompanyType = CompanyTypeCodes.TRC;
            tCompany.Address = GetAddressFixture();
            tCompany.Balance = 0;

            return tCompany;
        }

        public Company GetShipperCompanyFixture()
        {
            var company = new Company();
            company.CompanyName = "Shipper Company" + random.Next(1, 100);
            company.Email = "ShipperCompany " + RandomEmail;
            company.MembershipDate = DateTime.Now;
            company.Telephone = RandomNumber.ToString();
            company.TaxNumber = random.Next(1, 999999).ToString();
            company.TaxOffice = "shipper Vergi Dairesi" + random.Next(1, 999999);
            company.IsActive = true;
            company.CompanyType = CompanyTypeCodes.SIC;
            company.Address = GetAddressFixture();
            return company;
        }

        public Address GetAddressFixture()
        {
            var address = new Address()
            {
                AddressLine = "Apartman" + random.Next(1, 100),
                DateCreated = DateTime.Now,
                District = "Mahalle " + random.Next(1, 100),
                Country = _unitOfWork.CountryRepository.GetAll().FirstOrDefault(x => x.Id == 90),
                City = _unitOfWork.CityRepository.GetAll().FirstOrDefault(x => x.CityName == "MERSIN"),
                County = _unitOfWork.CountyRepository.GetAll().FirstOrDefault(x => x.CountyName == "TARSUS"),
                IsActive = true
            };

            return address;
        }

        public Location GetDriverLocationFixture()
        {
            var driverLocation = new LocationDriver()
            {
                DriverId = 24,
                DateCreated = DateTime.Now,
                Latitude = (decimal)53.3498,
                Longitude = (decimal)6.2603,
                LocationType = LocationTypeCodes.LocationDriver
            };

            return driverLocation;
        }

        public Freight GetFreightFixture()
        {
            var freight = new Freight()
            {
                FreightType = FreightTypeCode.Bulk,
                Description = "Vehicle needs tent",
                IsActive = true,
                IsTaken = false,
                DateCreated = DateTime.Now,
                DeliverByDate = DateTime.Now.AddDays(3),
                LoadingDate = DateTime.Today.AddDays(1),
                UnitPrice = 45,
                IsDelivered = false,
                IsFullVehicleQuantity = true,
                IsVatIncluded = true,
                Company = GetShipperCompanyFixture(),
                Address = GetAddressFixture(),
                DestinationAddress = GetAddressFixture()

            };

            return freight;
        }

        public OfferToFreight GetOfferFixture(IUnitOfWork unitOfWork)
        {
            var offer = new OfferToFreight()
            {
                OfferDate = DateTime.Now,
                Vehicle = unitOfWork.VehicleRepository.Get(2),
                Freight = unitOfWork.FreightRepository.Get(28),
                IsAccepted = false
            };

            return offer;
        }

        public JobOfferToDriver GetJobOfferFixture(IUnitOfWork _unitOfWork)
        {
            var jobOfferToDriver = new JobOfferToDriver()
            {
                Driver = _unitOfWork.UserRepository.Get(3),
                Vehicle = _unitOfWork.VehicleRepository.Get(3),
                DateCreated = DateTime.Now,
                IsAccepted = false
            };

            return jobOfferToDriver;
        }



    }
}
