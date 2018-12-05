using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Model;

namespace FreightFinder.Core.IServices
{
   public interface IVehicleLocationServices
   {
       bool AddNewVehicleLocation(VehicleLocation vehicleLocation);
   }
}
