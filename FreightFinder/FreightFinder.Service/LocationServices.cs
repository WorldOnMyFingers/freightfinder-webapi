using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Domain;
using FreightFinder.Core.IoC;
using FreightFinder.Core.IServices;

namespace FreightFinder.Service
{
    public class LocationServices : ILocationServices
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public LocationServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Location location)
        {
            _unitOfWork.LocationRepository.Add(location);
            _unitOfWork.Complete();
        }

        public IEnumerable<Location> GetLocationSet(int userId, DateTime startDate)
        {
            return _unitOfWork.DriverLocationRepository.GetAll().Where(x => x.DriverId == userId && x.DateCreated > startDate);
        }
    }
}
