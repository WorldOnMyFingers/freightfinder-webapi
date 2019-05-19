using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using FreightFinder.Core.Domain;
using FreightFinder.Core.IServices;
using FreightFinder.Core.ViewModels;

namespace WebApiFreightFinder.Controllers
{
    [System.Web.Http.AllowAnonymous]
    public class VehicleController : ApiController
    {
        private readonly IVehicleServices _vehicleServices;
        public VehicleController(IVehicleServices vehicleServices)
        {
            _vehicleServices = vehicleServices;
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        public IEnumerable<string> GetImageList(long id)
        {
            var list = _vehicleServices.GetImageList(id);

            return (list);
        }

        // GET api/<controller>/5
        public VehicleViewModel Get(int id)
        {
            var vehicleViewModel = _vehicleServices.Get(id);
            return vehicleViewModel;
        }

        // POST api/<controller>
        public void Post(Vehicle vehicle)
        {
            _vehicleServices.Add(vehicle);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}