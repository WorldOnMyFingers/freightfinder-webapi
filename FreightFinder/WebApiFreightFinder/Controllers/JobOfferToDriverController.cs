using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using FreightFinder.Core.Domain;
using FreightFinder.Core.IServices;
using Microsoft.AspNet.Identity;

namespace WebApiFreightFinder.Controllers
{
    [Authorize]
    public class JobOfferToDriverController : ApiController
    {
        private readonly IJobOfferToDriverServices _jobOfferToDriverServices;

        public JobOfferToDriverController(IJobOfferToDriverServices jobOfferToDriverServices)
        {
            _jobOfferToDriverServices = jobOfferToDriverServices;

        }

        // POST: api/JobOfferToDriver
        public void Post(JobOfferToDriver jobOfferToDriver)
        {
            _jobOfferToDriverServices.Add(jobOfferToDriver);
        }

        [HttpGet]
        public void AcceptJobOffer(int Id)
        {
            var userId = User.Identity.GetUserId();
            _jobOfferToDriverServices.AcceptJobOffer(Id, userId);
        }

        public void DetachDriver(int vehicleId)
        {
            _jobOfferToDriverServices.DetachDriverFromVehicle(vehicleId);
        }

        // PUT: api/JobOfferToDriver/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/JobOfferToDriver/5
        [HttpGet]
        public void Delete(int id)
        {
        }

        [HttpPut]
        public bool Test([FromBody]int Id)
        {
            return false;
        }
    }
}
