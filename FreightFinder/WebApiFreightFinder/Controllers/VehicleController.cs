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

        public HttpResponseMessage GetImage(string url)
        {
            var image = _vehicleServices.GetImage(url);
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(image.ToArray());
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
            return result;
        }


        public IEnumerable<string> GetImageUrlList(string plateNumber)
        {
            var list = new List<string>()
            {
                "/Users/emrebabayigit/Desktop/Drone/DJI_0029.JPG /Users/emrebabayigit/Downloads/download.jpeg",
                "/Users/emrebabayigit/Downloads/download.jpeg /Users/emrebabayigit/Downloads/image.jpg",
                "/Users/emrebabayigit/Downloads/scania-s-serie-highline-swedish-tanktrailer-tankcargo-Tekno-72802-30615.jpg"
            };

            return list;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
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