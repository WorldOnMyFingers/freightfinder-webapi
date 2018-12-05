using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FreightFinder.Core.Model;


namespace WebApiFreightFinder.Controllers
{
    public class ShipperCompanyController : ApiController
    {
        [System.Web.Http.HttpPut]
        [System.Web.Http.AllowAnonymous]
        public string Put(ShipperCompanyUser shipperCompanyUser)
        {
            //string taskStatus = "";
            //IShipperCompanyUserService iShipperCompanyUserService =
            //    new ShipperCompanyUserRepository();

            //iShipperCompanyUserService.AddNewShipperCompanyUser(shipperCompanyUser);
            


            return "";
        }
    }
}
