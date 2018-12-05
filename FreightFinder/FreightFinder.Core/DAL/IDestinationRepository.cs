using System.CodeDom.Compiler;
using System.Collections.Generic;
using FreightFinder.Core.Model;

namespace FreightFinder.Core.DAL
{
    public interface IDestinationRepository
    {
        bool AddNewDestination(Destination destination);
        bool DeleteDestinations(int destinationId);
        bool UpdateDestination(Destination destination);
        List<Destination> GetMyDestinations(int shipperCompanyId);
        Destination GetDestination(int destinationId);
    }
}