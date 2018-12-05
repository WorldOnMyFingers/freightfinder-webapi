using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FreightFinder.Core.Domain;
using FreightFinder.Core.IoC;
using FreightFinder.Core.IServices;
using FreightFinder.Core.ViewModels;
using System.Device.Location;

namespace FreightFinder.Service
{
    public class FreightServices : IFreightServices
    {
         private IUnitOfWork _unitOfWork { get; set; }

         public FreightServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Freight freight)
        {
            if(freight.Location == null)
            freight.Location = GetAddressCoordinates(freight.Address);

            _unitOfWork.FreightRepository.Add(freight);
            _unitOfWork.Complete();
        }

        public void Update(Freight freight)
        {
            _unitOfWork.FreightRepository.Update(freight);
            _unitOfWork.AddressRepository.Update(freight.Address);
            _unitOfWork.AddressRepository.Update(freight.DestinationAddress);
            _unitOfWork.LocationRepository.Update(freight.Location);
            _unitOfWork.Complete();
        }

        public void Delete(int freightId)
        {
            var freight = _unitOfWork.FreightRepository.Get(freightId);
            freight.IsActive = false;
            _unitOfWork.Complete();
        }

        public FreightViewModel GetFreight(long id)
        {
            var freight = _unitOfWork.FreightRepository.Get(id);
            return Mapper.Map<FreightViewModel>(freight);
        }

        public IEnumerable<FreightViewModel> GetFreights(CurrentLocationViewModel userCoordinates)
        {
            var freightsWithinDistance = new List<FreightViewModel>();
            try
            {
                var allFreights = _unitOfWork.FreightRepository.GetAll().Where(x => x.IsTaken == false && x.IsActive);
                foreach (var freight in allFreights)
                {
                    if (freight.Location != null)
                    {
                        var usersCoordinates = new GeoCoordinate((double)userCoordinates.Coordinates.Latitude,
                            (double)userCoordinates.Coordinates.Longitude);
                        var freightCoordinates = new GeoCoordinate((double)freight.Location.Latitude,
                            (double)freight.Location.Longitude);

                        var distance = usersCoordinates.GetDistanceTo(freightCoordinates);
                        if (distance / 1000 <= userCoordinates.Distance * 0.7)
                        {
                            
                            var viewModel = Mapper.Map<FreightViewModel>(freight);
                            freightsWithinDistance.Add(viewModel);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                var a = exception;
            }

            
            return freightsWithinDistance;
        }

        private Location GetAddressCoordinates(Address address)
        {
            Location location;
            if (address.County.Id == 0)
            {
                location = 
                    _unitOfWork.CityRepository.GetAll().FirstOrDefault(x => x.Id == address.City.Id).Coordinates;
            }
            else
            {
                location =
                    _unitOfWork.CountyRepository.GetAll().FirstOrDefault(x => x.Id == address.County.Id).Coordinates;
            }

            return location;
        }

        
    }
}
