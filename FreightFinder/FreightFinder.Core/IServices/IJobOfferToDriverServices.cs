using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Domain;

namespace FreightFinder.Core.IServices
{
    public interface IJobOfferToDriverServices
    {
        void Add(JobOfferToDriver jobOfferToDriver);

        void AcceptJobOffer(int jobOfferId, string userId);

        void DetachDriverFromVehicle(int vehicleId);

    }
}
