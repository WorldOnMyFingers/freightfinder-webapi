using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FreightFinder.Core.Domain;
using FreightFinder.Core.IServices;
using FreightFinder.Core.Model;
using FreightFinder.Core.ViewModels;
using FreightFinder.Service;


namespace WebApiFreightFinder.Controllers
{
    [AllowAnonymous]
    public class LocationController : ApiController
    {
        private readonly ILocationServices _locationServices;

        public LocationController(ILocationServices locationServices)
        {
            _locationServices = locationServices;
        }

        [HttpPost]
        public void Post(LocationViewModel location)
        {
            _locationServices.Add(location);
        }

        public IEnumerable<Location> Get(int userId, DateTime startDate)
        {
            return _locationServices.GetLocationSet(userId, startDate);
        }

        public LocationViewModel GetLocation(int userId)
        {
            return new LocationViewModel { Id = 1, Latitude = new decimal(2.3), Longitude = new decimal(3.3333), LocationType = FreightFinder.Core.Enums.LocationTypeCodes.LocationDriver };
        }
    }
}
