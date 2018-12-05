using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using FreightFinder.Core.Model;
using FreightFinder.Core.DAL;

namespace FreightFinder.DataAccess.Repositories
{
    public class TransportationCompanyServices : ITransportationCompanyService
    {

        public bool CreateNewTransportationCompany(TransportationCompanyUser transportationCompanyUser)
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

        public bool UpdateTransportationCompany(TransportationCompany transportationCompany)
        {
            bool isCommited = false;
            using (var context = new FreightFinder())
            {
                try
                {
                    var original = context.TransportationCompanies.Find(transportationCompany.TransportationCompanyId);

                    if (original != null)
                    {
                        context.Entry(original).CurrentValues.SetValues(transportationCompany);
                        context.Entry(original.Company).CurrentValues.SetValues(transportationCompany.Company);
                        context.SaveChanges();
                        isCommited = true;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    isCommited = false;
                }
            }


            return isCommited;
        }
        
        public bool DeleteTransportationCompany(int transportationCompanyId)
        {
            throw new System.NotImplementedException();
        }

        public TransportationCompany GetTransportationCompany(int transportationCompanyId)
        {
            
            TransportationCompany transportationCompany = new TransportationCompany();
            using (var context = new FreightFinder())
            {
                try
                {
                    transportationCompany =
                        context.TransportationCompanies.Where(x => x.TransportationCompanyId == transportationCompanyId)
                            .Include(a => a.Company)
                            .FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return transportationCompany;
        }




        public bool TransferCreditToVehicle(CreditTransfer creditTransfer)
        {
            bool isCommited = false;
            TransportationCompany transportationCompany;

            using (var context = new FreightFinder())
            {
                try
                {
                    var originalTransportationCompany = context.TransportationCompanies.Find(creditTransfer.CompanyId);

                    if (originalTransportationCompany.Balance >= creditTransfer.Amount)
                    {
                        transportationCompany = originalTransportationCompany;
                        transportationCompany.Balance = originalTransportationCompany.Balance - creditTransfer.Amount;
                        creditTransfer.CompanyBalance = transportationCompany.Balance;

                        if (originalTransportationCompany != null && creditTransfer != null)
                        {
                            context.CreditTransfers.Add(creditTransfer);
                            context.Entry(originalTransportationCompany).CurrentValues.SetValues(transportationCompany);
                            context.SaveChanges();
                            isCommited = true;
                        }
                    }

                }
                catch (Exception)
                {
                    isCommited = false;
                    throw;
                }
            }

            return isCommited;
        }


        public List<CreditTransfer> ViewMyTransferHistory(int transportationCompanyId)
        {
            List<CreditTransfer> creditTransfers = new List<CreditTransfer>();
            using (var context = new FreightFinder())
            {
                try
                {
                    creditTransfers = context.CreditTransfers.Where(x => x.CompanyId == transportationCompanyId)
                        .Include(a=>a.Vehicle)
                        .ToList();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return creditTransfers;
        }
    }
}