using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FreightFinder.Core.Domain;
using FreightFinder.Core.ViewModels;

namespace FreightFinder.Core.Mapping
{
    public class FreightFinderMapper : Profile
    {
        public FreightFinderMapper() : base(typeof(FreightFinderMapper).Name)
        {
            DtoToViewModelForFreight();
            DtoToViewModelForAddress();
            DtoToViewModelForCountry();
            DtoToViewModelForCity();
            DtoToViewModelForCounty();
        }
        public void DtoToViewModelForFreight()
        {
            CreateMap<Freight, FreightViewModel>()
                .ForMember(x => x.Id, m => m.MapFrom(s => s.Id))
                .ForMember(x => x.DateCreated, m => m.MapFrom(s => s.DateCreated))
                .ForMember(x => x.DateTaken, m => m.MapFrom(s => s.DateTaken))
                .ForMember(x => x.DeliverByDate, m => m.MapFrom(s => s.DeliverByDate))
                .ForMember(x => x.LoadingDate, m => m.MapFrom(s => s.LoadingDate))
                .ForMember(x => x.Description, m => m.MapFrom(s => s.Description))
                .ForMember(x => x.IsActive, m => m.MapFrom(s => s.IsActive))
                .ForMember(x => x.IsDelivered, m => m.MapFrom(s => s.IsDelivered))
                .ForMember(x => x.IsFullVehicleQuantity, m => m.MapFrom(s => s.IsFullVehicleQuantity))
                .ForMember(x => x.IsVatIncluded, m => m.MapFrom(s => s.IsVatIncluded))
                .ForMember(x => x.FreightType, m => m.MapFrom(s => s.FreightType))
                .ForMember(x => x.TotalPrice, m => m.MapFrom(s => s.TotalPrice))
                .ForMember(x => x.UnitPrice, m => m.MapFrom(s => s.UnitPrice))
                .ForMember(x => x.Weight, m => m.MapFrom(s => s.Weight))
                .ForMember(x => x.Address, m => m.MapFrom(s => s.Address))
                .ForMember(x => x.DestinationAddress, m => m.MapFrom(s => s.DestinationAddress))
                .ForMember(x => x.Location, m => m.MapFrom(s => s.Location))
                .ForMember(x => x.IsTaken, m => m.MapFrom(s => s.IsTaken));
        }

        public void DtoToViewModelForAddress()
        {
            CreateMap<Address, AddressViewModel>()
                .ForMember(x => x.AddressLine, m => m.MapFrom(s => s.AddressLine))
                .ForMember(x => x.City, m => m.MapFrom(s => s.City.CityName))
                .ForMember(x => x.County, m => m.MapFrom(s => s.County.CountyName))
                .ForMember(x => x.Country, m => m.MapFrom(s => s.Country.CountryName))
                .ForMember(x => x.AddressLine, m => m.MapFrom(s => s.AddressLine))
                .ForMember(x => x.District, m => m.MapFrom(s => s.District));
        }

        public void DtoToViewModelForCountry()
        {
            CreateMap<Country, AddressViewModel>()
                .ForMember(x => x.Country, m => m.MapFrom(s => s.CountryName));
        }

        public void DtoToViewModelForCity()
        {
            CreateMap<City, AddressViewModel>()
                .ForMember(x => x.City, m => m.MapFrom(s => s.CityName));
        }

        public void DtoToViewModelForCounty()
        {
            CreateMap<County, AddressViewModel>()
                .ForMember(x => x.County, m => m.MapFrom(s => s.CountyName));
        }
    }
}
