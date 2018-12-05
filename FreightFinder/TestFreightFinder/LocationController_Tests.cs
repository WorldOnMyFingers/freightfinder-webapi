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
    public class LocationController_Tests
    {
        public LocationController _LocationController { protected get; set; }
        public ILocationServices _LocationServices { protected get; set; }
        public IUnitOfWork _unitOfWork { protected get; set; }
        private Fixtures _fixtures { get; set; }
        private Random _random { get; set; }


        [TestInitialize]
        public void Initialize()
        {
            _unitOfWork = Substitute.For<UnitOfWork>();
            _LocationServices = Substitute.For<LocationServices>(_unitOfWork);
            _LocationController = Substitute.For<LocationController>(_LocationServices);
            _fixtures = Substitute.For<Fixtures>(_unitOfWork);
            _random = new Random();
        }

        #region Post

        [TestMethod]
        public void PostDriverLocation()
        {
            var driverLocation = _fixtures.GetDriverLocationFixture();
            _LocationController.Post(driverLocation);

            var location =_unitOfWork.LocationRepository.Get((int)driverLocation.Id); 

            Assert.AreEqual(location.Id, driverLocation.Id);
            Assert.AreEqual(location.Latitude, driverLocation.Latitude);
            Assert.AreEqual(location.Longitude, driverLocation.Longitude);
            Assert.AreEqual(location.LocationType, driverLocation.LocationType);
        }
        #endregion

        [TestMethod]
        public void GetLocations()
        {
            var date = new DateTime(2017, 03, 25);
            var locations = _LocationController.Get(24, date);

        }
    }
}
