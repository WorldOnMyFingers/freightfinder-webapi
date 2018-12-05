using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Model;

namespace FreightFinder.Core.DAL
{
    public interface IVehicleLocationRepository
    {
        bool AddNewVehicleLocation(VehicleLocation vehicleLocation);

    }
}
