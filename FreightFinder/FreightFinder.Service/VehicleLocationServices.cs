using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.DAL;
using FreightFinder.Core.IServices;
using FreightFinder.Core.Model;
using FreightFinder.DataAccess.Repositories;

namespace FreightFinder.Service
{
    public class VehicleLocationServices : IVehicleLocationServices
    {

        public bool AddNewVehicleLocation(VehicleLocation vehicleLocation)
        {
            bool isCommitted;
            IVehicleLocationRepository iVehicleLocationRepository = new VehicleLocationRepository();
            isCommitted = iVehicleLocationRepository.AddNewVehicleLocation(vehicleLocation);
            return isCommitted;
        }
    }
}
