using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using FreightFinder.Core.Model;
using FreightFinder.Core.Services;
using Microsoft.SqlServer.Server;

namespace FreightFinder.DataAccess
{
    public class ShipperCompanyUserServices :IShipperCompanyUserService
    {


        public Core.Model.ShipperCompanyUser GetShipperCompanyUser(int shipperCompanyUserId)
        {
            ShipperCompanyUser shipperCompanyUser = new ShipperCompanyUser();
            using (var context = new FreightFinder())
            {
                try
                {
                    shipperCompanyUser =
                        context.ShipperCompanyUsers.Where(x => x.Id == shipperCompanyUserId)
                            .Include(a => a.User).FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return shipperCompanyUser;
        }

        public System.Collections.Generic.List<Core.Model.ShipperCompanyUser> GetShipperCompanyUsers(int shipperCompanyId)
        {
            List<ShipperCompanyUser> shipperCompanyUsers = new List<ShipperCompanyUser>();
            using (var context = new FreightFinder())
            {
                try
                {
                    shipperCompanyUsers =
                        context.ShipperCompanyUsers.Where(x => x.BusinessId == shipperCompanyId).Include(a => a.User).ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return shipperCompanyUsers;
        }

        public bool AddNewShipperCompanyUser(ShipperCompanyUser shipperCompanyUser)
        {
            bool isCommited;
            using (var context = new FreightFinder())
            {
                try
                {
                    context.ShipperCompanyUsers.Add(shipperCompanyUser);
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

        public bool UpdateShipperCompanyUser(ShipperCompanyUser shipperCompanyUser)
        {
            bool isCommited = false;
            using (var context = new FreightFinder())
            {
                try
                {
                    var original = 
                        context.ShipperCompanyUsers.Where(x => x.Id == shipperCompanyUser.Id).Include(a => a.User).FirstOrDefault();

                    if (original != null)
                    {
                        context.Entry(original).CurrentValues.SetValues(shipperCompanyUser);
                        context.Entry(original.User).CurrentValues.SetValues(shipperCompanyUser.User);
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

        public bool DeleteShipperCompanyUser(int shipperCompanyUserId)
        {
            bool isCommited;
            using (var context = new FreightFinder())
            {
                try
                {
                    var shipperCompanyUser = context.ShipperCompanyUsers.Find(shipperCompanyUserId);
                    context.Users.Remove(shipperCompanyUser.User);
                    context.ShipperCompanyUsers.Remove(shipperCompanyUser);
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