using System;
namespace FreightFinder.Core.ViewModels
{
    public class PostUserViewModel
    {
        public PostUserViewModel()
        {
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Surename { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string CountryId { get; set; }

        public string CityId { get; set; }

        public string CountyId { get; set; }

        public string District { get; set; }

        public string AddressLine { get; set; }
    }
}
