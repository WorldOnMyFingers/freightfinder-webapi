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
    public class VehicleServices : IVehicleServices
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public VehicleServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Add(Vehicle vehicle)
        {
            _unitOfWork.VehicleRepository.Add(vehicle);
            _unitOfWork.Complete();

            return true;
        }
    }
}
