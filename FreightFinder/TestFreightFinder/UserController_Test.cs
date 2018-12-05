using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core;
using FreightFinder.Core.Domain;
using FreightFinder.Core.Enums;
using FreightFinder.Core.IServices;
using FreightFinder.DAL;
using FreightFinder.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using WebApiFreightFinder.Controllers;
using FreightFinder.Core.IoC;

namespace TestFreightFinder
{
    [TestClass]
    public class UserController_Test
    {
        public UserController _UserController { protected get; set; }
        public IUserServices _UserServices { protected get; set; }
        public IUnitOfWork _unitOfWork { protected get; set; }
        private Fixtures _fixtures { get; set; }
        private Random _random { get; set; }


        [TestInitialize]
        public void Initialize()
        {
            _unitOfWork = Substitute.For<UnitOfWork>();
            _UserServices = Substitute.For<UserServices>(_unitOfWork);
            _UserController = Substitute.For<UserController>(_UserServices);
            _fixtures = Substitute.For<Fixtures>(_unitOfWork);
            _random = new Random();
        }

        #region Post

        [TestMethod]
        public void PostOnlyUser_Test()
        {
            var user = _fixtures.GetUserFixture();
            user.UserType = UserType.Driver;
            _UserController.Post(user);

            var insertedUser = _unitOfWork.UserRepository.GetAll().OrderByDescending(x => x.DateCreated).FirstOrDefault();

            Assert.AreEqual(user.DateOfBirth, insertedUser.DateOfBirth);
            Assert.AreEqual(user.Mobile, insertedUser.Mobile);
            Assert.AreEqual(user.Name, insertedUser.Name);

        }

        [TestMethod]
        public void PostUserWithTransportationCompany_Test()
        {
            var user = _fixtures.GetUserFixture();
            user.UserType = UserType.TransportationCompanyUser;
            user.Company = _fixtures.GetTransportationCompanyFixture();

            _UserController.Post(user);

            var insertedUser = _unitOfWork.UserRepository.GetAll().OrderByDescending(x => x.DateCreated).FirstOrDefault();

            Assert.AreEqual(user.DateOfBirth, insertedUser.DateOfBirth);
            Assert.AreEqual(user.Mobile, insertedUser.Mobile);
            Assert.AreEqual(user.Name, insertedUser.Name);
            Assert.AreEqual(user.Company.CompanyName, insertedUser.Company.CompanyName);
            Assert.AreEqual(user.Company.Address.City, insertedUser.Company.Address.City);
        }

        [TestMethod]
        public void PostUserWithShipperCompany_Test()
        {
            var user = _fixtures.GetUserFixture();
            user.UserType = UserType.ShipperCompanyUser;
            user.Company = _fixtures.GetShipperCompanyFixture();

            _UserController.Post(user);

            var insertedUser = _unitOfWork.UserRepository.GetAll().OrderByDescending(x => x.DateCreated).FirstOrDefault();

            Assert.AreEqual(user.DateOfBirth, insertedUser.DateOfBirth);
            Assert.AreEqual(user.Mobile, insertedUser.Mobile);
            Assert.AreEqual(user.Name, insertedUser.Name);
            Assert.AreEqual(user.Company.CompanyName, insertedUser.Company.CompanyName);
            Assert.AreEqual(user.Company.Address.City, insertedUser.Company.Address.City);
        }

        #endregion

        #region Put

        [TestMethod]
        public void PutUser()
        {
            var user = new User()
            {
                Name = "Integ name",
                Email = "integemail@email.com",
                DateOfBirth = DateTime.Today,
                Mobile = "0000000",
                NationalIdentity = 111111111,
                Password = "integ password",
                Surename = "integ surename",
                Username = "integ username",
                UserType = UserType.ShipperCompanyUser,
                PicturePath = "PicturePathhhhhh",
                Id = "ec5eaab2-ba7f-4f45-ba19-5b1e69db70b9"
            };

            _UserController.Put(user);

            var updatedUser = _unitOfWork.UserRepository.Get(user.Id);

            Assert.AreEqual(user.Name, updatedUser.Name);
            Assert.AreEqual(user.Username, updatedUser.Username);
            Assert.AreEqual(user.Surename, updatedUser.Surename);

        }
        #endregion

        [TestMethod]
        public void Get()
        {
            var user = _unitOfWork.UserRepository.GetAll()
                .FirstOrDefault();
            var credentials = _UserServices.GetCredentials(user.Id);
           Assert.AreEqual(credentials.Email, user.Email);

        }
    }
}
