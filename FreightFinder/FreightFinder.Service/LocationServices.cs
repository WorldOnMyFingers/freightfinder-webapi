using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FreightFinder.Core.Domain;
using FreightFinder.Core.IoC;
using FreightFinder.Core.IServices;
using FreightFinder.Core.ViewModels;

namespace FreightFinder.Service
{
    public class LocationServices : ILocationServices
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public LocationServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(LocationViewModel locationViewModel)
        {
            try
            {
                var location = Mapper.Map<Location>(locationViewModel);
                _unitOfWork.LocationRepository.Add(location);
                _unitOfWork.Complete();
            }
            catch(Exception e)
            {
                var message = e.Message;
            }
        }

        public IEnumerable<Location> GetLocationSet(int userId, DateTime startDate)
        {
            return _unitOfWork.DriverLocationRepository.GetAll().Where(x => x.DriverId == userId && x.DateCreated > startDate);
        }
    }
}
