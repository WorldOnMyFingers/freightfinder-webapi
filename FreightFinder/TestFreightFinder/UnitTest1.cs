using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FreightFinder.Core.Model;
using WebApiFreightFinder;
using WebApiFreightFinder.Controllers;

namespace TestFreightFinder
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddNewLocation()
        {
            VehicleLocation vehicleLocation = new VehicleLocation()
            {
                Date = DateTime.UtcNow,
                Lat = (decimal)40.7128,
                Lon = (decimal)74.0059,
                VehicleId = 3
            };
            
            LocationController locationController = new LocationController();
            locationController.Post(vehicleLocation);
        }
    }
}
