using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FreightFinder.Core.Model;
using FreightFinder.Core.Services;

namespace FreightFinder.DataAccess
{
    public class TransportationCompanyUserServices : ITransportationCompanyUserService
    {

        public TransportationCompanyUser GetTransportationCompanyUser(int transportationCompanyId)
        {
            TransportationCompanyUser transportationCompanyUser = new TransportationCompanyUser();
            using (var context = new FreightFinder())
            {
                try
                {
                    transportationCompanyUser =
                        context.TransportationCompanyUsers.Where(x => x.Id == transportationCompanyId)
                            .Include(a => a.User).FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return transportationCompanyUser;
        }

        public List<TransportationCompanyUser> GetTransportationCompanyUsers(int transportationCompanyId)
        {
            List<TransportationCompanyUser> transportationCompanyUsers = new List<TransportationCompanyUser>();
            using (var context = new FreightFinder())
            {
                try
                {
                    transportationCompanyUsers =
                        context.TransportationCompanyUsers.Where(x => x.CompanyId == transportationCompanyId)
                        .Include(a => a.User)
                        .ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return transportationCompanyUsers;
        }

        public bool AddNewTransportationCompanyUser(TransportationCompanyUser transportationCompanyUser)
        {
            bool isCommited;
            using (var context = new FreightFinder())
            {
                try
                {
                    context.TransportationCompanyUsers.Add(transportationCompanyUser);
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

        public bool UpdateTransportationCompanyUser(TransportationCompanyUser transportationCompanyUser)
        {
            bool isCommited = false;
            using (var context = new FreightFinder())
            {
                try
                {
                    var original =
                        context.TransportationCompanyUsers.Where(x => x.Id == transportationCompanyUser.Id).Include(a => a.User).FirstOrDefault();

                    if (original != null)
                    {
                        context.Entry(original).CurrentValues.SetValues(transportationCompanyUser);
                        context.Entry(original.User).CurrentValues.SetValues(transportationCompanyUser.User);
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

        public bool DeleteTransportationCompanyUser(int transportationCompanyUserId)
        {
            bool isCommited;
            using (var context = new FreightFinder())
            {
                try
                {
                    var transportationCompanyUser = context.TransportationCompanyUsers.Find(transportationCompanyUserId);
                    context.Users.Remove(transportationCompanyUser.User);
                    context.TransportationCompanyUsers.Remove(transportationCompanyUser);
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