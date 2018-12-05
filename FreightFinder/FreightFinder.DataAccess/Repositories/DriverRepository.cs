using System;
using System.Data.Entity;
using System.Linq;
using FreightFinder.Core.Model;
using FreightFinder.Core.DAL;

namespace FreightFinder.DataAccess.Repositories
{
    public class DriverServices : IDriverService
    {

        public Driver GetDriver(int driverId)
        {
            Driver driver = new Driver();
            using (var context = new FreightFinder())
            {
                try
                {
                    driver =
                        context.Drivers.Where(x => x.DriverId == driverId)
                            .Include(a => a.User).FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return driver;
        }

        public bool AddNewDriver(Driver driver)
        {
            bool isCommited;
            using (var context = new FreightFinder())
            {
                try
                {
                    context.Drivers.Add(driver);
                    context.SaveChanges();
                    isCommited = true;
                }
                catch (Exception)
                {
                    isCommited = false;
                    Console.WriteLine();
                }
            }
            return isCommited;
        }

        public bool UpdateDriver(Core.Model.Driver driver)
        {
            bool isCommited = false;
            using (var context = new FreightFinder())
            {
                try
                {
                    var original =
                        context.Drivers.Where(x => x.DriverId == driver.DriverId).Include(a => a.User).FirstOrDefault();

                    if (original != null)
                    {
                        context.Entry(original).CurrentValues.SetValues(driver);
                        context.Entry(original.User).CurrentValues.SetValues(driver.User);
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

        public bool DeleteDriver(int driverId)
        {
            bool isCommited;
            using (var context = new FreightFinder())
            {
                try
                {
                    var driver = context.Drivers.Find(driverId);
                    context.Users.Remove(driver.User);
                    context.Drivers.Remove(driver);
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
    }
}