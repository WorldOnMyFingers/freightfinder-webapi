using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.DAL;
using FreightFinder.Core.Model;

namespace FreightFinder.DataAccess.Repositories
{
    public class VehicleLocationRepository : IVehicleLocationRepository
    {
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
            return isCommited;
        }

        
    }
}
