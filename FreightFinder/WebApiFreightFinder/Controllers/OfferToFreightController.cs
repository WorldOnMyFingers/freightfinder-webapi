using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FreightFinder.Core.Domain;
using FreightFinder.Core.IServices;
using FreightFinder.Core.ViewModels;

namespace WebApiFreightFinder.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/offertofreight")]
    public class OfferToFreightController : ApiController
    {
        private readonly IOfferToFreightServices _offerToFreightServices;

        public OfferToFreightController(IOfferToFreightServices offerToFreightServices)
        {
            _offerToFreightServices = offerToFreightServices;
        }

        // GET: api/OfferToFreight
        public IEnumerable<OfferToFreight> Get(int freightId)
        {
            var offers = _offerToFreightServices.GetOffers(freightId);
            return offers;
        }

        public FreightOfferDetailsViewModel GetOffer(int offerId)
        {
            var offerDetailsViewModel = _offerToFreightServices.GetOffer(offerId);
            return offerDetailsViewModel;
        }


        // POST: api/OfferToFreight
        [Route("Post"), HttpPost]
        [AllowAnonymous]
        public int Post([FromBody] ApplyToFreightViewModel offerToFreightViewModel)
        {
            return _offerToFreightServices.Add(
                offerToFreightViewModel.UserId, 
                Convert.ToInt64(offerToFreightViewModel.FreightId));
        }

        [HttpGet, AllowAnonymous]
        public IEnumerable<OfferToFreightViewModel> MyOffers(string vehiclePlateNumber)
        {
            var offers = _offerToFreightServices.GetMyOffers(vehiclePlateNumber).ToList();

            return offers;
        }

        public void AcceptOffer(int offerId)
        {
            _offerToFreightServices.Accept(offerId);
        }

        // PUT: api/OfferToFreight/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/OfferToFreight/5
        public void Delete(int id)
        {
        }
    }
}
