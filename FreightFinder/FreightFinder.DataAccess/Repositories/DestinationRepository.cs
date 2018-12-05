using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using FreightFinder.Core.Model;
using FreightFinder.Core.DAL;

namespace FreightFinder.DataAccess.Repositories
{
    public class DestinationRepository : IDestinationRepository
    {

        public bool AddNewDestination(Core.Model.Destination destination)
        {

            bool isCommited;
            using (var context = new FreightFinder())
            {
                try
                {
                    context.Destinations.Add(destination);
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

        public bool DeleteDestinations(int destinationId)
        {
            bool isCommited;
            using (var context = new FreightFinder())
            {
                try
                {
                    var destination = context.Destinations.Find(destinationId);
                    context.Destinations.Remove(destination);
                    context.SaveChanges();
                    isCommited = true;
                }
                catch (Exception )
                {
                    isCommited = false;
                    Console.WriteLine();
                }
            }
            
            return isCommited;
        }

        public bool UpdateDestination(Core.Model.Destination destination)
        {
            bool isCommited;
            using (var context = new FreightFinder())
            {
                try
                {
                    var original = context.Destinations.Find(destination.DestinationId);
                    context.Entry(original).CurrentValues.SetValues(destination);
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

        public System.Collections.Generic.List<Core.Model.Destination> GetMyDestinations(int shipperCompanyId)
        {
            List<Destination> listOfDestinations = new List<Destination>();
            using (var context = new FreightFinder())
            {
                try
                {
                    listOfDestinations = new List<Destination>(context.Destinations.Where(x => x.BusinessId == shipperCompanyId)).ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return listOfDestinations;
        }


        public Destination GetDestination(int destinationId)
        {
            Destination destination = new Destination();

            using (var context = new FreightFinder())
            {
                try
                {
                    destination = context.Destinations.Find(destinationId);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return destination;
        }
    }
}