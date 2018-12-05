using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FreightFinder.Core.Domain;
using FreightFinder.Core.IServices;
using FreightFinder.Core.Model;
using FreightFinder.Service;

namespace WebApiFreightFinder.Controllers
{
    public class LocationController : ApiController
    {
        private readonly ILocationServices _locationServices;

        public LocationController(ILocationServices locationServices)
        {
            _locationServices = locationServices;
        }

        public void Post(Location location)
        {
            _locationServices.Add(location);
        }

        public IEnumerable<Location> Get(int userId, DateTime startDate)
        {
            return _locationServices.GetLocationSet(userId, startDate);
        }
    }
}
