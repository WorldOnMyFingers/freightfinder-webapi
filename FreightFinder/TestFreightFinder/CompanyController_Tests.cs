using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.IoC;
using FreightFinder.Core.IServices;
using FreightFinder.DAL;
using FreightFinder.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using WebApiFreightFinder.Controllers;

namespace TestFreightFinder
{
    [TestClass]
    public class CompanyController_Tests
    {
        public CompanyController _CompanyController { protected get; set; }
        public ICompanyService _CompanyServices { protected get; set; }
        public IUnitOfWork _unitOfWork { protected get; set; }
        private Fixtures _fixtures { get; set; }
        private Random _random { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            _unitOfWork = Substitute.For<UnitOfWork>();
            _CompanyServices = Substitute.For<CompanyService>(_unitOfWork);
            _CompanyController = Substitute.For<CompanyController>(_CompanyServices);
            _fixtures = Substitute.For<Fixtures>(_unitOfWork);
            _random = new Random();
        }

        #region Post

        [TestMethod]
        public void Post_HappyCase()
        {
            var user = _fixtures.GetUserFixture();
            _unitOfWork.UserRepository.Add(user);
            _unitOfWork.Complete();

            var company = _fixtures.GetTransportationCompanyFixture();
            var result = _CompanyController.Post(company, user.Id);

            Assert.AreEqual(result, true);

            var userFromDb = _unitOfWork.UserRepository.Get(user.Id);

            Assert.AreEqual(userFromDb.Company.Id, company.Id);
            Assert.AreEqual(userFromDb.Company.CompanyName, company.CompanyName);
            Assert.AreEqual(userFromDb.Id, user.Id);
            Assert.AreNotEqual(userFromDb.Company, null);
        }

        [TestMethod]
        public void Post_UserAlreadyHasCompany()
        {
            var user = _fixtures.GetUserFixture();
            user.Company = _fixtures.GetTransportationCompanyFixture();
            _unitOfWork.UserRepository.Add(user);
            _unitOfWork.Complete();

            var company = _fixtures.GetTransportationCompanyFixture();
            var result = _CompanyController.Post(company, user.Id);

            Assert.AreEqual(result, false);

            var userFromDb = _unitOfWork.UserRepository.Get(user.Id);

            Assert.AreNotEqual(userFromDb.Company.Id, company.Id);
            Assert.AreEqual(userFromDb.Company.Id, user.Company.Id);
        }

        #endregion

        [TestMethod]
        public void Get()
        {
            var companyFixture = _fixtures.GetShipperCompanyFixture();
            _unitOfWork.CompanyRepository.Add(companyFixture);
            _unitOfWork.Complete();
            var company = _unitOfWork.CompanyRepository.Get(companyFixture.Id);

            Assert.AreEqual(companyFixture.Id, company.Id);
            Assert.AreEqual(companyFixture.CompanyName, company.CompanyName);
            Assert.AreEqual(companyFixture.Email, company.Email);
            Assert.AreEqual(companyFixture.CompanyType, company.CompanyType);

        }

        
    }
}
