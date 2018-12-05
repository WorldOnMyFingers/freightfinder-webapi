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
    public class FreightController : ApiController
    {
        private readonly IFreightServices _freightServices;

        public FreightController(IFreightServices freightServices)
        {
            _freightServices = freightServices;

        }
        // GET: api/Freight
        public IEnumerable<FreightViewModel> Get(CurrentLocationViewModel coordinates)
        {
            var freightsWithinDistance = _freightServices.GetFreights(coordinates);

            return freightsWithinDistance;
        }

        public List<FreightViewModel> GetFreight(decimal lon, decimal lat, int distance)
        {
            var coordinates = new CurrentLocationViewModel() { Coordinates = new Coordinates() { Latitude = lat, Longitude = lon }, Distance = distance };
            var freightsWithinDistance = _freightServices.GetFreights(coordinates);

            return freightsWithinDistance.ToList();
        }


        // POST: api/Freight
        [HttpPost]
        public void Post(Freight freight)
        {
            _freightServices.Add(freight);
        }

     
        [HttpPost]
        public string Add(string userId, string freightId)
        {
            var s = userId;
            return "emre";
        }

        // PUT: api/Freight/5
        public void Put(Freight freight)
        {
            _freightServices.Update(freight);
        }

        // DELETE: api/Freight/5
        [HttpGet]
        public void Delete(int id)
        {
            _freightServices.Delete(id);
        }

        [HttpGet]
        public List<string> Test(int id)
        {
            return new List<string>() { "Merhaba", "Ben", "Emre" };
        }

        [HttpGet]
        public List<string> Get(int id)
        {
            return new List<string>() { "Merhaba", "Ben", "Emre" };
        }

        [HttpGet]
        [Route("api/freights/mytest")]
        public List<string> Test()
        {
            return new List<string>() { "Merhaba", "Ben", "Emre" };
        }

    }
}
