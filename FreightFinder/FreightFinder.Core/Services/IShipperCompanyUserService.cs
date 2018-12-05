using System.Collections.Generic;
using FreightFinder.Core.Model;

namespace FreightFinder.Core.Services
{
    public interface IShipperCompanyUserService
    {
        ShipperCompanyUser GetShipperCompanyUser(int shipperCompanyUserId);
        List<ShipperCompanyUser> GetShipperCompanyUsers(int shipperCompanyId); 
        bool AddNewShipperCompanyUser(ShipperCompanyUser shipperCompanyUser);
        bool UpdateShipperCompanyUser(ShipperCompanyUser shipperCompanyUser);
        bool DeleteShipperCompanyUser(int userId);

    }
}