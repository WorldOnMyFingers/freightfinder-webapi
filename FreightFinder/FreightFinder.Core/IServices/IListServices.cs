using System;
using System.Collections.Generic;
using FreightFinder.Core.ViewModels;

namespace FreightFinder.Core.IServices
{
    public interface IListServices
    {
        IEnumerable<DropDownIdNameViewModel> GetCountries();
        IEnumerable<DropDownIdNameViewModel> GetCities();
        IEnumerable<DropDownIdNameViewModel> GetCounties();
    }
}
