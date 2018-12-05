using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Domain;
using FreightFinder.Core.IServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiFreightFinder.Controllers;
using FreightFinder.Core.IoC;
using FreightFinder.DAL;
using FreightFinder.Service;
using NSubstitute;

namespace TestFreightFinder
{
    [TestClass]
    public class JobOfferToDriverController_Tests
    {
        public JobOfferToDriverController _JobOfferToDriverController { protected get; set; }
        public IJobOfferToDriverServices _IJobOfferToDriverServices { protected get; set; }
        public IUnitOfWork _unitOfWork { protected get; set; }
        private Fixtures _fixtures { get; set; }
        private Random _random { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            _unitOfWork = Substitute.For<UnitOfWork>();
            _IJobOfferToDriverServices = Substitute.For<JobOfferToDriverServices>(_unitOfWork);
            _JobOfferToDriverController = Substitute.For<JobOfferToDriverController>(_IJobOfferToDriverServices);
            _fixtures = Substitute.For<Fixtures>(_unitOfWork);
            _random = new Random();
        }

        [TestMethod]
        public void Post_Test()
        {
            var jobOfferToDriver = _fixtures.GetJobOfferFixture(_unitOfWork);
            _JobOfferToDriverController.Post(jobOfferToDriver);

            var result = _unitOfWork.JobOfferToDriverRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault();

            Assert.AreEqual(jobOfferToDriver.Driver.Id, result.Driver.Id);
            Assert.AreEqual(jobOfferToDriver.Vehicle.Id, result.Vehicle.Id);
        }

        [TestMethod]
        public void AcceptJobOffer_Test()
        {
            var offerId = 1;
            _JobOfferToDriverController.AcceptJobOffer(offerId);

            var result = _unitOfWork.JobOfferToDriverRepository.Get(offerId);

            Assert.AreEqual(result.IsAccepted, true);
            Assert.AreNotEqual(result.DateAccepted, null);
        }

        [TestMethod]
        public void DetachDriver()
        {
            var vehicleId = 3;
            _JobOfferToDriverController.DetachDriver(vehicleId);

            var result = _unitOfWork.VehicleRepository.Get(vehicleId);

            Assert.AreEqual(result.Driver, null);
            Assert.AreEqual(result.Driver.Company, null);
        }
    }
}
