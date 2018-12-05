using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Domain;
using FreightFinder.Core.Enums;
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
    public class VehicleController_Tests
    {
        public VehicleController _VehicleController { protected get; set; }
        public IVehicleServices _VehicleServices { protected get; set; }
        public IUnitOfWork _unitOfWork { protected get; set; }
        private Fixtures _fixtures { get; set; }
        private Random random { get; set; }


        [TestInitialize]
        public void Initialize()
        {
            _unitOfWork = Substitute.For<UnitOfWork>();
            _VehicleServices = Substitute.For<VehicleServices>(_unitOfWork);
            _VehicleController = Substitute.For<VehicleController>(_VehicleServices);
            _fixtures = Substitute.For<Fixtures>(_unitOfWork);
            random = new Random();
        }

        #region Fixtures
        private int RandomLongNumber
        {
            get { return random.Next(700000000, 900000000); }
        }

        public Colour GetColourFixture()
        {
            var colour = _unitOfWork.ColourRepository.GetAll().FirstOrDefault(x => x.Code == "RED");

            return colour;
        }

        public VehicleBrand GetVehicleBrand()
        {
            var brand = _unitOfWork.VehicleBrandRepository.GetAll().FirstOrDefault(x => x.Code == "SCN");

            return brand;
        }

        public VehicleModel GetVehicleModel()
        {
            var model = _unitOfWork.VehicleModelRepository.GetAll().FirstOrDefault(x => x.Code == "G42");

            return model;
        }

        public Vehicle GetVehicle()
        {
            var vehicle = new Vehicle()
            {
                Capacity = 28,
                Brand = GetVehicleBrand(),
                Model = GetVehicleModel(),
                Colour = GetColourFixture(),
                Company = _unitOfWork.TransportationCompanyRepository.GetAll().FirstOrDefault(),
                EngineNumber = RandomLongNumber.ToString(),
                VehicleIdentificationNumber = RandomLongNumber.ToString(),
                PicturePath = "VehiclePhotoPath",
                PlateNumber = "66LA442",
                VehicleType = VehicleType.Tipper,
                IsActive = true,
                IsLoaded = true,
                DateCreated = DateTime.Today
            };

            return vehicle;
        }

        #endregion

        [TestMethod]
        public void PostVehicle_Test()
        {
            var vehicle = GetVehicle();

            _VehicleController.Post(vehicle);

            var insertedVehicle = _unitOfWork.VehicleRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault();

            Assert.AreEqual(insertedVehicle.EngineNumber, vehicle.EngineNumber);
            Assert.AreEqual(insertedVehicle.VehicleIdentificationNumber, vehicle.VehicleIdentificationNumber);
            Assert.AreEqual(insertedVehicle.Model.Code, vehicle.Model.Code);
        }

        

    }
}
