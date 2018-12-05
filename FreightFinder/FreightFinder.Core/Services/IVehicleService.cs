using System.Collections.Generic;
using FreightFinder.Core.Model;

namespace FreightFinder.Core.Services
{
    public interface IVehicleService
    {
        Vehicle GetVehicle(int vehicleId);
        List<Vehicle> GetVehicles(int transportationCompanyId);

        bool AddNewVehicle(Vehicle vehicle);
        bool UpdateVehicle(Vehicle vehicle);
        bool DeleteVehicle(int vehicleId);

        bool AddNewVehicleLocation(VehicleLocation vehicleLocation);
        VehicleLocation GetVehicleLocation(int vehicleId);
        bool AddNewTransaction(Transaction transaction);
        List<Transaction> ViewMyTransactions(int vehicleId);

    }
}