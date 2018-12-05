using System.Collections.Generic;
using FreightFinder.Core.Model;

namespace FreightFinder.Core.DAL
{
    public interface ITransportationCompanyService
    {
        bool CreateNewTransportationCompany(TransportationCompanyUser transportationCompanyUser);
        bool UpdateTransportationCompany(TransportationCompany transportationCompany);
        bool DeleteTransportationCompany(int transportationCompanyId);
        TransportationCompany GetTransportationCompany(int transportationCompany);

        bool TransferCreditToVehicle(CreditTransfer creditTransfer);
        List<CreditTransfer> ViewMyTransferHistory(int transportationCompanyId);

    }
}