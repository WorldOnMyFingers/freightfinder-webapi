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
        public IEnumerable<DropDownIdNameViewModel> GetCounties()
        {
            return _listServices.GetCounties();
        }

        [HttpGet]
        public IEnumerable<DropDownIdNameViewModel> GetCitites()
        {
            return _listServices.GetCities();
        }
    }
}
