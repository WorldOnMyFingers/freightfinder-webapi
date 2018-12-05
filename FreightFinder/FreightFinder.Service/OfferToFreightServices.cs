using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Domain;
using FreightFinder.Core.Enums;
using FreightFinder.Core.IoC;
using FreightFinder.Core.IServices;
using FreightFinder.Core.ViewModels;

namespace FreightFinder.Service
{
    public class OfferToFreightServices : IOfferToFreightServices
    {
        private IUnitOfWork _unitOfWork { get; set; }
        private IFreightServices _freightServices { get; set; }

        public OfferToFreightServices(IUnitOfWork unitOfWork, IFreightServices freightServices)
        {
            _unitOfWork = unitOfWork;
            _freightServices = freightServices;
        }

        public int Add(string userId, long freightId)
        {
            var vehicle = _unitOfWork.VehicleRepository.GetAll().FirstOrDefault(x => x.Driver != null && x.Driver.Id == userId);
            if (vehicle != null)
            {
                var offers = _unitOfWork.OfferToFreightRepository.GetAll()
                    .Where(x => x.Freight.Id == freightId && x.Vehicle.Id == vehicle.Id);

                if (!offers.Any())
                {
                    var user = _unitOfWork.UserRepository.Get(userId);
                    var freight = _unitOfWork.FreightRepository.Get(freightId);

                    if (user != null && freight != null)
                    {
                        if (user.UserType == UserType.Driver)
                        {
                            var offerToFreight = new OfferToFreight()
                            {
                                Vehicle = vehicle,
                                Freight = freight,
                                IsAccepted = false,
                                IsActive = true,
                                OfferDate = DateTime.Now
                            };
                            _unitOfWork.OfferToFreightRepository.Add(offerToFreight);
                            _unitOfWork.Complete();
                        }
                    }
                }
                else
                {
                    return (int)ErrorSringsEnumValues.AlreadyHasAnOffer;
                }
            }
            else
            {
                return (int)ErrorSringsEnumValues.NoVehicleAttachedToTheUser;
            }

            return (int)ErrorSringsEnumValues.OfferHasBeenAddedForTheFreight;
        }

        public void Accept(int offerId)
        {
            var offer = _unitOfWork.OfferToFreightRepository.Get(offerId);
            if (offer.Freight.IsTaken == false && offer.Vehicle.IsLoaded == false)
            {
                offer.IsAccepted = true;
                offer.DateAccepted = DateTime.Now;

                offer.Freight.DateTaken = DateTime.Now;
                offer.Freight.Vehicle = offer.Vehicle;
                offer.Vehicle.IsLoaded = true;
                offer.Freight.IsTaken = true;
                _unitOfWork.Complete();
            }
        }

        public IEnumerable<OfferToFreight> GetOffers(int freightId)
        {
            var offers = _unitOfWork.OfferToFreightRepository.GetAll().Where(x => x.Freight.Id == freightId);
            return offers;
        }

        public IEnumerable<OfferToFreightViewModel> GetMyOffers(string vehiclePlateNumber)
        {
            var offers = _unitOfWork.OfferToFreightRepository.GetAll().Where(x => x.Vehicle.PlateNumber == vehiclePlateNumber && x.IsActive).Select(x => new OfferToFreightViewModel
            {
                OfferId = x.Id,
                FreightId = x.Freight.Id,
                DateAccepted = x.DateAccepted,
                IsAccepted = x.IsAccepted,
                OfferDate = x.OfferDate,
                From = x.Freight.Address.County.CountyName + "/" + x.Freight.Address.City.CityName,
                To = x.Freight.DestinationAddress.County.CountyName + "/" + x.Freight.DestinationAddress.City.CityName,
                Price = x.Freight.TotalPrice.HasValue ? string.Format("{0:#.00}", Convert.ToDecimal(x.Freight.TotalPrice.ToString())) : string.Format("{0:#.00}{1}", Convert.ToDecimal(x.Freight.UnitPrice.ToString()), "/Kg"),
                Weight = x.Freight.Weight.ToString(),
                FreightType = x.Freight.FreightType

            });
              
            return offers;
        }
    }
}
