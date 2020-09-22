using System;
namespace FreightFinder.Core.ViewModels
{
    public class PostAddressViewModel
    {
        public PostAddressViewModel()
        {
        }

        public string CountryId { get; set; }
        public string CityId { get; set; }
        public string CountyId { get; set; }
        public string District { get; set; }
        public string AddressLine { get; set; }
        public string Phone { get; set; }
    }
}
