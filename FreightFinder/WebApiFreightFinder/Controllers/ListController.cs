using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using FreightFinder.Core.IServices;
using FreightFinder.Core.ViewModels;

namespace WebApiFreightFinder.Controllers
{
    [AllowAnonymous]
    public class ListController : ApiController
    {
        private readonly IListServices _listServices;

        public ListController(IListServices listServices)
        {
            _listServices = listServices;
        }

        [HttpGet]
        public IEnumerable<DropDownIdNameViewModel> GetCountries()
        {
            return _listServices.GetCountries();
        }

        [HttpGet]
        public IEnumerable<DropDownIdNameViewModel> GetCities(int countryId)
        {
            return _listServices.GetCities(countryId);
        }

        [HttpGet]
        public IEnumerable<DropDownIdNameViewModel> GetCounties(int cityId)
        {
            return _listServices.GetCounties(cityId);
        }

        [HttpGet]
        public IEnumerable<DropDownNameValueViewModel> GetVehicleBrands()
        {
            return _listServices.GetVehicleBrands();
        }

        [HttpGet]
        public IEnumerable<DropDownNameValueViewModel> GetVehicleModels(string brandCode)
        {
            return _listServices.GetVehicleModels(brandCode);
        }

        [HttpGet]
        public IEnumerable<DropDownNameValueViewModel> GetColors()
        {
            return _listServices.GetColors();
        }

    }
}
