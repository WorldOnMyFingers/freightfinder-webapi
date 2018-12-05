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
    public class OfferToFreightController_Tests
    {
        public OfferToFreightController _OfferToFreightController { protected get; set; }
        public IOfferToFreightServices _OfferToFreightServices { protected get; set; }
        public IUnitOfWork _unitOfWork { protected get; set; }
        private Fixtures _fixtures { get; set; }
        private Random _random { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            _unitOfWork = Substitute.For<UnitOfWork>();
            _OfferToFreightServices = Substitute.For<OfferToFreightServices>(_unitOfWork);
            _OfferToFreightController = Substitute.For<OfferToFreightController>(_OfferToFreightServices);
            _fixtures = Substitute.For<Fixtures>(_unitOfWork);
            _random = new Random();
        }

        [TestMethod]
        public void OfferToFreightPost()
        {
            var offer = _fixtures.GetOfferFixture(_unitOfWork);

            //_OfferToFreightController.Post("85a62ad2-6b32-4f75-bc4e-8e6bc81d4e00", "30");
        }

        [TestMethod]
        public void GetOffers()
        {
            var offer = _fixtures.GetOfferFixture(_unitOfWork);

            _unitOfWork.OfferToFreightRepository.Add(offer);
            _unitOfWork.Complete();

            var offers = _OfferToFreightController.Get(28);


            Assert.AreEqual(offers.Count(), 2);
        }

        [TestMethod]
        public void AcceptOffer()
        {
            var offerId = 2;
            _OfferToFreightController.AcceptOffer(offerId);

            var offer = _unitOfWork.OfferToFreightRepository.Get(offerId);
            

        }

    }

    
}
