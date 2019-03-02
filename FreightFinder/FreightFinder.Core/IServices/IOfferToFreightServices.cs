using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Domain;
using FreightFinder.Core.ViewModels;

namespace FreightFinder.Core.IServices
{
    public interface IOfferToFreightServices
    {
        int Add(string userId, long freightId);
        void Accept(int offerId);
        FreightOfferDetailsViewModel GetOffer(int offerId);
        IEnumerable<OfferToFreight> GetOffers(int freightId);
        IEnumerable<OfferToFreightViewModel> GetMyOffers(string vehiclePlateNumber);

    }
}
