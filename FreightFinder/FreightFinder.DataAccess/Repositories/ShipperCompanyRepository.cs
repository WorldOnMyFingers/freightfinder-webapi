using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Model;
using FreightFinder.Core.DAL;

namespace FreightFinder.DataAccess.Repositories
{
   public class ShipperCompanyServices :IShipperCompanyService
    {

       public ShipperCompany GetBusiness(int shipperCompanyId)
       {
           ShipperCompany shipperCompany = new ShipperCompany();
           using (var context = new FreightFinder())
           {

               try
               {
                   shipperCompany = 
                        context.ShipperCompanies.Where(x => x.ShipperCompanyId == shipperCompanyId).Include(a => a.Company).FirstOrDefault();
               }
               catch (Exception)
               {
                   
                   throw;
               }
               
           }

           return shipperCompany;
       }


       public bool CreateNewBusiness(ShipperCompanyUser shipperCompanyUser)
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

       public bool UpdateBusiness(ShipperCompany shipperCompany)
       {
           bool isCommited = false;
           using (var context = new FreightFinder())
           {
               
               var original = context.ShipperCompanies.Find(shipperCompany.ShipperCompanyId);

               if (original != null)
               {
                   try
                   {
                       
                       context.Entry(original).CurrentValues.SetValues(shipperCompany);
                       context.Entry(original.Company).CurrentValues.SetValues((shipperCompany.Company));
                       context.SaveChanges();
                       isCommited = true;
                   }
                   catch (Exception e)
                   {
                       isCommited = false;
                       Console.WriteLine(e);
                   }

               }
           }
           return isCommited;
       }

       public bool DeleteBusiness(int businessId)
       {
           throw new NotImplementedException();
       }

    }
}
