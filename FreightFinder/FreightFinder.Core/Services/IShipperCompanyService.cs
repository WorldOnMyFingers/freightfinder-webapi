using FreightFinder.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreightFinder.Core.Services
{
    public interface IShipperCompanyService
    {
        ShipperCompany GetBusiness(int shipperCompanyId);
        bool CreateNewBusiness(ShipperCompanyUser shipperCompanyUser );
        bool UpdateBusiness(ShipperCompany shipperCompany);
        bool DeleteBusiness(int businessId);



    }
}
