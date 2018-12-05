using System.Collections.Generic;
using FreightFinder.Core.Model;

namespace FreightFinder.Core.Services
{
    public interface ITransportationCompanyUserService
    {
        TransportationCompanyUser GetTransportationCompanyUser(int transportationCompanyId);
        List<TransportationCompanyUser> GetTransportationCompanyUsers(int transportationCompanyId);
        bool AddNewTransportationCompanyUser(TransportationCompanyUser transportationCompanyUser);
        bool UpdateTransportationCompanyUser(TransportationCompanyUser transportationCompanyUser);
        bool DeleteTransportationCompanyUser(int userId);
    }
}