using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Domain;
using FreightFinder.Core.Enums;
using FreightFinder.Core.IoC;
using FreightFinder.Core.IServices;
using FreightFinder.Core.ViewModels;
using FreightFinder.DAL;
using FreightFinder.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using WebApiFreightFinder.Controllers;

namespace TestFreightFinder
{
    [TestClass]
    public class FreightController_Tests
    {
        public FreightController _FreightController { protected get; set; }
        public IFreightServices _FreightServices { protected get; set; }
        public IUnitOfWork _unitOfWork { protected get; set; }
        private Fixtures _fixtures { get; set; }
        private Random _random { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            _unitOfWork = Substitute.For<UnitOfWork>();
            _FreightServices = Substitute.For<FreightServices>(_unitOfWork);
            _FreightController = Substitute.For<FreightController>(_FreightServices);
            _fixtures = Substitute.For<Fixtures>(_unitOfWork);
            _random = new Random();
        }

        private Freight GetFreightFixture()
        {
            var freight = new Freight()
            {
                FreightType = FreightTypeCode.Bulk,
                Description = "very urgent",
                DateCreated = DateTime.Now,
                LoadingDate = DateTime.Today.AddDays(1),
                DeliverByDate = DateTime.Today.AddDays(7),
                Weight = _random.Next(10000, 25000),
                IsActive = true,
                IsDelivered = false,
                IsVatIncluded = false,
                UnitPrice = 45,
                Address = _fixtures.GetAddressFixture(),
                DestinationAddress = _fixtures.GetAddressFixture(),
                Company = _unitOfWork.CompanyRepository.Get(6)
                
            };

            return freight;
        }

        [TestMethod]
        public void FreightPost()
        {
            var freight = GetFreightFixture();
            
            _FreightController.Post(freight);

           var insertedFreight = _unitOfWork.FreightRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault();
           Assert.AreEqual(insertedFreight.Description, freight.Description);
           Assert.AreEqual(insertedFreight.FreightType, freight.FreightType);
           Assert.AreEqual(insertedFreight.IsDelivered, freight.IsDelivered);
           Assert.AreEqual(insertedFreight.LoadingDate, freight.LoadingDate);
           Assert.AreEqual(insertedFreight.Location.Latitude, freight.Location.Latitude);
           Assert.AreEqual(insertedFreight.Location.Longitude, freight.Location.Longitude);
        }

        [TestMethod]
        public void FreightPut()
        {
            var freight = GetFreightFixture();
            freight.Id = _random.Next(0, 28);
            freight.Company = null;
            freight.DestinationAddress = null;
            _FreightController.Put(freight);

            var insertedFreight = _unitOfWork.FreightRepository.Get((int)freight.Id);

            Assert.AreEqual(insertedFreight.Description, freight.Description);
            Assert.AreEqual(insertedFreight.FreightType, freight.FreightType);
            Assert.AreEqual(insertedFreight.IsDelivered, freight.IsDelivered);
            Assert.AreEqual(insertedFreight.LoadingDate, freight.LoadingDate);
        }

        [TestMethod]
        public void FindDistance()
        {
            var sorgun = _unitOfWork.CountyRepository.GetAll()
                .FirstOrDefault(x => x.CountyName == "SORGUN").Coordinates;
            var yerkoy = _unitOfWork.CountyRepository.GetAll()
                .FirstOrDefault(x => x.CountyName == "YERKÖY").Coordinates;
            var sCoord = new GeoCoordinate((double)sorgun.Latitude, (double)sorgun.Longitude);
            var eCoord = new GeoCoordinate((double)yerkoy.Latitude, (double)yerkoy.Longitude);

            var distance = sCoord.GetDistanceTo(eCoord)/1000;
        }

        [TestMethod]
        public void Get_FreightsWithCoordinates()
        {
            var freights = _unitOfWork.FreightRepository.GetAll();
            freights.ToList().ForEach(x => x.IsActive = false);
            _unitOfWork.Complete();

            var currentLocation = _unitOfWork.CountyRepository.GetAll()
                .FirstOrDefault(x => x.CountyName == "SORGUN").Coordinates;
            var freight1 = GetFreightFixture();
            freight1.Address.County = _unitOfWork.CountyRepository.GetAll()
                .FirstOrDefault(x => x.CountyName == "YERKÖY");
            _FreightController.Post(freight1);

            var freight2 = GetFreightFixture();
            freight2.Address.County = _unitOfWork.CountyRepository.GetAll()
                .FirstOrDefault(x => x.CountyName == "AKDAGMADENI");
            _FreightController.Post(freight2);

            var freight3 = GetFreightFixture();
            freight3.Address.County = _unitOfWork.CountyRepository.GetAll()
                .FirstOrDefault(x => x.CountyName == "KADISEHRI");
            _FreightController.Post(freight3);

            var freight4 = GetFreightFixture();
            freight4.Address.County = _unitOfWork.CountyRepository.GetAll()
                .FirstOrDefault(x => x.CountyName == "TALAS");
            _FreightController.Post(freight4);

            var searchFreightVM = new CurrentLocationViewModel()
            {
                Coordinates = new Coordinates()
                {
                    Latitude = currentLocation.Latitude,
                    Longitude = currentLocation.Longitude,
                },
                Distance = 100
            };
            var results = _FreightController.Get(searchFreightVM);

            Assert.AreEqual(results.Count(), 3);
        }

        [TestMethod]
        public void Update_FreightStatus()
        {
            var freight = _unitOfWork.FreightRepository.Get(27);
            freight.IsActive = false;
            _unitOfWork.Complete();
        }

        [TestMethod]
        public void Delete_Freight()
        {
            var freight = _unitOfWork.FreightRepository.GetAll()
                .FirstOrDefault(x => x.IsActive && x.IsTaken == false);
            _FreightController.Delete((int)freight.Id);

            var result = _unitOfWork.FreightRepository.Get(freight.Id);

            Assert.AreEqual(result.IsActive, false);

        }

    }
}
