using System;
using System.Collections.Generic;
using FreightFinder.Core.ViewModels;

namespace FreightFinder.Core.IServices
{
    public interface IListServices
    {
        IEnumerable<DropDownIdNameViewModel> GetCountries();
        IEnumerable<DropDownIdNameViewModel> GetCities(int countryId);
        IEnumerable<DropDownIdNameViewModel> GetCounties(int cityId);
        IEnumerable<DropDownNameValueViewModel> GetVehicleBrands();
        IEnumerable<DropDownNameValueViewModel> GetVehicleModels(string brandCode);
        IEnumerable<DropDownNameValueViewModel> GetColors();
    }
}
