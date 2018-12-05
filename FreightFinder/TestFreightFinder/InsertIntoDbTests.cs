using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FreightFinder.Core.Domain;
using FreightFinder.Core.IoC;
using FreightFinder.DAL;
using NSubstitute;

namespace TestFreightFinder
{
    /// <summary>
    /// Summary description for CompanyTests
    /// </summary>
    [TestClass]
    public class InsertIntoDbTests
    {
        public IUnitOfWork _unitOfWork { protected get; set; }

        private Random random = new Random();
        public InsertIntoDbTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [TestInitialize]
        public void Setup()
        {
            _unitOfWork = Substitute.For<UnitOfWork>();
        }

        private TestContext testContextInstance;



        public Company SetupShipperCompany()
        {
            var company = new Company();
            company.CompanyName = "Naira Factory" + random.Next(1, 100);
            company.Email = "email" + random.Next(1, 100) + "@email.com";
            company.MembershipDate = DateTime.Now;
            company.Telephone = random.Next(1, 999999).ToString();
            company.TaxNumber = random.Next(1, 999999).ToString();
            company.TaxOffice = "Egricam Vergi Dairesi" + random.Next(1, 999999);
            company.IsActive = true;
            company.CompanyType = CompanyTypeCodes.SIC;
            company.Address = setupAddress();
            return company;
        }

        public TransportationCompany SetupTransportationCompany()
        {
            var tCompany = new TransportationCompany();
            tCompany.CompanyName = "Ozbabayigitler Transport" + random.Next(1, 100);
            tCompany.Email = "transportation" + random.Next(1, 100) + "@email.com";
            tCompany.MembershipDate = DateTime.Now;
            tCompany.Telephone = random.Next(1, 999999).ToString();
            tCompany.TaxNumber = random.Next(1, 999999).ToString();
            tCompany.TaxOffice = "Sorgun Vergi Dairesi" + random.Next(1, 999999);
            tCompany.IsActive = true;
            tCompany.CompanyType = CompanyTypeCodes.TRC;
            tCompany.Address = setupAddress();
            tCompany.Balance = 0;
            return tCompany;
        }

        private CompanyType setupCompanyType()
        {
            var companyType = _unitOfWork.CompanyTypeRepository.GetAll()
                .FirstOrDefault(x => x.Code == CompanyTypeCodes.TRC.ToString());
            
            return companyType;
        }

        private Address setupAddress()
        {
            var address = new Address()
            {
                AddressLine = "Semiha Apartmani" + random.Next(1, 100),
                DateCreated = DateTime.Now,
                District = "Egricam mahalesi" + random.Next(1, 100),
                Country = _unitOfWork.CountryRepository.GetAll().FirstOrDefault(x => x.CountryName == "Turkey"),
                City = _unitOfWork.CityRepository.GetAll().FirstOrDefault(x => x.CityName == "Mersin"),
                County = _unitOfWork.CountyRepository.GetAll().FirstOrDefault(x => x.CountyName == "Tarsus"),
                IsActive = true
            };

            return address;
        }

        public Country setupCountry()
        {

            var country = _unitOfWork.CountryRepository.GetAll().FirstOrDefault(x => x.CountryName == "Turkey");

            return country;
        }

        private City setupCity()
        {
            var city = _unitOfWork.CityRepository.GetAll().FirstOrDefault(x => x.CityName == "Mersin");
            return city;
        }

        private County setupCounty()
        {
            var county = new County()
            {
                CountyName = "Tarsus",
                IsActive = true,
                City = _unitOfWork.CityRepository.GetAll().FirstOrDefault(x => x.CityName == "Mersin")
            };

            return county;
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void InsertCountry_Test()
        {
            var country = setupCountry();
            _unitOfWork.CountryRepository.Add(country);
            _unitOfWork.Complete();

        }

        [TestMethod]
        public void InsertCity_Test()
        {
            var city = setupCity();
            _unitOfWork.CityRepository.Add(city);
            _unitOfWork.Complete();

        }

        [TestMethod]
        public void InsertCounty_Test()
        {
            var county = setupCounty();
            _unitOfWork.CountyRepository.Add(county);
            _unitOfWork.Complete();

        }

        [TestMethod]
        public void InsertAddress_Test()
        {
            var address = setupAddress();
            _unitOfWork.AddressRepository.Add(address);
            _unitOfWork.Complete();

        }

        [TestMethod]
        public void InsertCompanyType_Test()
        {
            var companyType = setupCompanyType();
            _unitOfWork.CompanyTypeRepository.Add(companyType);
            _unitOfWork.Complete();

        }

        [TestMethod]
        public void InsertCompany_Test()
        {
            var company = SetupShipperCompany();
            _unitOfWork.CompanyRepository.Add(company);
            _unitOfWork.Complete();

        }

        [TestMethod]
        public void InsertTransportationCompany_Test()
        {
            var tCompany = SetupTransportationCompany();
            _unitOfWork.TransportationCompanyRepository.Add(tCompany);
            _unitOfWork.Complete();

        }
    }
}
