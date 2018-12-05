using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using FreightFinder.Core.Model;
using FreightFinder.Core.Services;

namespace FreightFinder.DataAccess
{
    public class VehicleServices : IVehicleService
    {

        public Vehicle GetVehicle(int vehicleId)
        {
            Vehicle vehicle = new Vehicle();
            using (var context = new FreightFinder())
            {
                try
                {
                    vehicle = context.Vehicles.Find(vehicleId);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return vehicle;
        }

        public List<Vehicle> GetVehicles(int transportationCompanyId)
        {
            List<Vehicle> listOfVehicles = new List<Vehicle>();
            using (var context = new FreightFinder())
            {
                try
                {
                    listOfVehicles = (from c in context.Vehicles
                        where c.CompanyId == transportationCompanyId
                        select c).ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }
            return listOfVehicles;
        }

        public bool AddNewVehicle(Vehicle vehicle)
        {
            bool isCommited;
            using (var context = new FreightFinder())
            {
                try
                {
                    context.Vehicles.Add(vehicle);
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

        public bool UpdateVehicle(Vehicle vehicle)
        {
            bool isCommited = false;
            using (var context = new FreightFinder())
            {
                var original = context.Vehicles.Find(vehicle.VehicleId);

                if (original != null)
                {
                    try
                    {
                        context.Entry(original).CurrentValues.SetValues(vehicle);
                        context.SaveChanges();
                        isCommited = true;
                    }
                    catch (DbEntityValidationException e)
                    {

                        foreach (var eve in e.EntityValidationErrors)
                        {

                            Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                eve.Entry.Entity.GetType().Name, eve.Entry.State);
                            foreach (var ve in eve.ValidationErrors)
                            {
                                Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                    ve.PropertyName, ve.ErrorMessage);

                            }
                        }
                        isCommited = false;
                    }
                }
            }

            return isCommited;
        }

        public bool DeleteVehicle(int vehicleId)
        {
            bool isCommited;

            using (var context = new FreightFinder())
            {
                try
                {
                    var vehicle = context.Vehicles.Find(vehicleId);
                    context.Vehicles.Remove(vehicle);
                    context.SaveChanges();
                    isCommited = true;
                }
                catch (Exception e)
                {
                    isCommited = false;
                    Console.WriteLine(e);
                }
            }
            return isCommited;
        }


        public bool AddNewVehicleLocation(VehicleLocation vehicleLocation)
        {
            bool isCommited;

            using (var context = new FreightFinder())
            {
                try
                {
                    context.VehicleLocations.Add(vehicleLocation);
                    context.SaveChanges();
                    isCommited = true;
                }
                catch (Exception)
                {
                    isCommited = false;
                    throw;
                }
            }

            return isCommited;
        }




        public bool AddNewTransaction(Transaction transaction)
        {
            bool isCommited;

            using (var context = new FreightFinder())
            {
                try
                {
                    context.Transactions.Add(transaction);
                    context.SaveChanges();
                    isCommited = true;
                }
                catch (Exception)
                {
                    isCommited = false;
                    throw;
                }
            }

            return isCommited;
        }


        public List<Transaction> ViewMyTransactions(int vehicleId)
        {
            List<Transaction> transactions = new List<Transaction>();
            using (var context = new FreightFinder())
            {
                try
                {
                    transactions = context.Transactions.Where(x => x.VehicleId == vehicleId)
                        .Include(a => a.OffersToFreight.FreightAd)
                        .ToList();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return transactions;
        }


        public VehicleLocation GetVehicleLocation(int vehicleId)
        {
            VehicleLocation vehicleLocation = new VehicleLocation();
            using (var context = new FreightFinder())
            {
                try
                {
                    vehicleLocation = context.VehicleLocations.Where(x=>x.VehicleId == vehicleId)
                        .OrderBy(a=>a.Date)
                        .FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return vehicleLocation;
        }
    }
}