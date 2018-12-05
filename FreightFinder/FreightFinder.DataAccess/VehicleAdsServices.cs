using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FreightFinder.Core.Model;
using FreightFinder.Core.Services;

namespace FreightFinder.DataAccess
{
    public class VehicleAdsServices : IVehicleAdsService
    {

        public List<VehicleAd> ViewMyAllVehicleAdsHistory(int vehicleId)
        {
            List<VehicleAd> transportationCompanyUsers = new List<VehicleAd>();
            using (var context = new FreightFinder())
            {
                try
                {
                    transportationCompanyUsers =
                        context.VehicleAds.Where(x => x.VehicleId == vehicleId && x.IsValid == false  )
                        .Include(a => a.Vehicle)
                        .ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return transportationCompanyUsers;
        }

        public VehicleAd ViewVehicleAd(int vehicleAdId)
        {
            VehicleAd vehicleAd = new VehicleAd();
            using (var context = new FreightFinder())
            {
                try
                {
                    vehicleAd =
                        context.VehicleAds.Where(x => x.VehicleAdId == vehicleAdId)
                            .Include(a => a.Vehicle)
                            .FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return vehicleAd;
        }

        public bool AddNewVehicleAd(VehicleAd vehicleAd)
        {
            bool isCommited;
            using (var context = new FreightFinder())
            {
                try
                {
                    context.VehicleAds.Add(vehicleAd);
                    context.SaveChanges();
                    isCommited = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    isCommited = false;
                }
            }

            return isCommited;
        }

        public bool UpdateVehicleAd(VehicleAd vehicleAd)
        {
            bool isCommited = false;
            using (var context = new FreightFinder())
            {
                try
                {
                    var original =
                        context.VehicleAds.Where(x => x.VehicleAdId == vehicleAd.VehicleAdId).Include(a => a.Vehicle).FirstOrDefault();

                    if (original != null)
                    {
                        context.Entry(original).CurrentValues.SetValues(vehicleAd);
                        context.SaveChanges();
                        isCommited = true;
                    }

                }
                catch (Exception)
                {
                    isCommited = false;
                    Console.WriteLine();
                }
            }
            return isCommited;
        }

        public bool DeleteVehicleAd(int vehicleAdId)
        {
            bool isCommited;
            using (var context = new FreightFinder())
            {
                try
                {
                    var vehicleAd = context.VehicleAds.Find(vehicleAdId);
                    context.VehicleAds.Remove(vehicleAd);
                    context.SaveChanges();
                    isCommited = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    isCommited = false;
                }
            }
            return isCommited;
        }


        public List<VehicleAd> ViewAllVehicleAds()
        {
            List<VehicleAd> listOfVehiclesAds = new List<VehicleAd>();
            using (var context = new FreightFinder())
            {
                try
                {
                    listOfVehiclesAds =
                        context.VehicleAds.Where(x => x.IsTaken == false && x.IsValid == true )
                        .OrderBy(q=> q.VehicleAdId)
                        .Include(a => a.Vehicle)
                        .ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return listOfVehiclesAds;
        }
    }
}