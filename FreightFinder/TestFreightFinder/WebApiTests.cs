using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using FreightFinder.Core.IoC;
using FreightFinder.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiFreightFinder.Controllers;
using Autofac;
using FreightFinder.Core.IServices;
using FreightFinder.Service;
using NSubstitute;

namespace TestFreightFinder
{
    /// <summary>
    /// Summary description for WebApiTests
    /// </summary>
    [TestClass]
    public class WebApiTests
    {
        public CompanyController _companyController { protected get; set; }
        public ICompanyService _companyService { protected get; set; }
        private InsertIntoDbTests _fixture = new InsertIntoDbTests();
        public IUnitOfWork _unitOfWork { protected get; set; }
        public IContainer Container { protected get; set; }

        [TestInitialize]
        public void Initialize()
        {
            _unitOfWork = Substitute.For<UnitOfWork>();
            _companyService = Substitute.For<CompanyService>(_unitOfWork);
            _companyController = Substitute.For<CompanyController>(_companyService);
            
        }

        private TestContext testContextInstance;

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
        public void PostTransportationCompanyTest()
        {
            _fixture._unitOfWork = _unitOfWork;
            var transportationCompany = _fixture.SetupTransportationCompany(); 
            _companyController.Post(transportationCompany, 2.ToString());
            var transportationCompanyFromDb =
                _unitOfWork.CompanyRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault();

            Assert.AreEqual(transportationCompany.CompanyName, transportationCompanyFromDb.CompanyName);
            Assert.AreEqual(transportationCompany.Email, transportationCompanyFromDb.Email);
            
        }
    }
}
