using System.Collections.Generic;
using FreightFinder.Core.Model;

namespace FreightFinder.Core.Services
{
    public interface IVehicleAdsService
    {
        List<VehicleAd> ViewMyAllVehicleAdsHistory(int vehicleId);
        List<VehicleAd> ViewAllVehicleAds();
        VehicleAd ViewVehicleAd(int vehicleAdId);
        bool AddNewVehicleAd(VehicleAd vehicleAd);
        bool UpdateVehicleAd(VehicleAd vehicleAd);
        bool DeleteVehicleAd(int vehicleAdId);

    }
}