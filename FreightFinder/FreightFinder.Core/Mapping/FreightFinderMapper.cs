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
            PostToDtoForAddress();
            PostToDomainForUser();
            DtoToViewModelForCountry();
            DtoToViewModelForCity();
            DtoToViewModelForCounty();
            ViewModelToDtoForLocation();
            DtoToViewModelForFreightOffer();
            DomainToViewModelForUser();
            DomainToViewModelForImagePath();
            DomainToViewModelForVehicle();
            DomainToViewModelForCountry();
            DomainToViewModelForCounty();
            DomainToViewModelForCity();
            DomainToViewModelForVehicleBrand();
            DomainToViewModelForVehicleModel();
            DomainToViewModelForColor();
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
                .ForMember(x => x.Phone, m => m.MapFrom(s => s.Phone))
                .ForMember(x => x.District, m => m.MapFrom(s => s.District));
        }

        public void PostToDtoForAddress()
        {
            CreateMap<PostAddressViewModel, Address>()
                .ForMember(x => x.AddressLine, m => m.MapFrom(s => s.AddressLine))
                .ForMember(x => x.Phone, m => m.MapFrom(s => s.Phone))
                .ForMember(x => x.District, m => m.MapFrom(s => s.District));
        }

        public void ViewModelToDtoForLocation()
        {
            CreateMap<LocationViewModel, Location>()
                .ForMember(x => x.Id, m => m.MapFrom(s => s.Id))
                .ForMember(x => x.Latitude, m => m.MapFrom(s => s.Latitude))
                .ForMember(x => x.Longitude, m => m.MapFrom(s => s.Longitude))
                .ForMember(x => x.LocationType, m => m.MapFrom(s => s.LocationType));
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

        public void DtoToViewModelForFreightOffer()
        {
            CreateMap<OfferToFreight, FreightOfferDetailsViewModel>()
            .ForMember(x => x.Id, m => m.MapFrom(s => s.Id))
            .ForMember(x => x.IsAccepted, m => m.MapFrom(s => s.IsAccepted))
            .ForMember(x => x.OfferDate, m => m.MapFrom(s => s.OfferDate))
            .ForMember(x => x.DateAccepted, m => m.MapFrom(s => s.DateAccepted));
        }

        public void DomainToViewModelForUser()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.ImagePaths, m => m.MapFrom(src => src.ImagePaths.Select(x => x.Name)));
        }

        public void PostToDomainForUser()
        {
            CreateMap<PostUserViewModel, User>()
                .ForMember(dest => dest.Id, m => m.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, m => m.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surename, m => m.MapFrom(src => src.Surename))
                .ForMember(dest => dest.Mobile, m => m.MapFrom(src => src.Mobile))
                .ForMember(dest => dest.Email, m => m.MapFrom(src => src.Email));
        }

        public void DomainToViewModelForImagePath()
        {
            CreateMap<UserImagePath, ImagePathViewModel>();
            CreateMap<VehicleImagePath, ImagePathViewModel>();
        }

        public void DomainToViewModelForVehicle()
        {
            CreateMap<Vehicle, VehicleViewModel>()
                .ForMember(dest => dest.Id, m => m.MapFrom(src => src.Id))
                .ForMember(dest => dest.BrandCode, m => m.MapFrom(src => src.Brand.Code))
                .ForMember(dest => dest.Capacity, m => m.MapFrom(src => src.Capacity))
                .ForMember(dest => dest.ColourCode, m => m.MapFrom(src => src.Colour.Code))
                .ForMember(dest => dest.Year, m => m.MapFrom(src => src.Year))
                .ForMember(dest => dest.Company, m => m.MapFrom(src => src.Company.CompanyName))
                .ForMember(dest => dest.DateCreated, m => m.MapFrom(src => src.DateCreated))
                .ForMember(dest => dest.EngineNumber, m => m.MapFrom(src => src.EngineNumber))
                .ForMember(dest => dest.IsLoaded, m => m.MapFrom(src => src.IsLoaded))
                .ForMember(dest => dest.ModelCode, m => m.MapFrom(src => src.Model.Code))
                .ForMember(dest => dest.PlateNumber, m => m.MapFrom(src => src.PlateNumber))
                .ForMember(dest => dest.VehicleIdentificationNumber, m => m.MapFrom(src => src.VehicleIdentificationNumber))
                .ForMember(dest => dest.VehicleType, m => m.MapFrom(src => src.VehicleType))
                .ForMember(dest => dest.TrailerType, m => m.MapFrom(src => src.TrailerType))
                .ForMember(dest => dest.ImagePaths, m => m.MapFrom(src => src.ImagePaths.Select(x => x.Name)));
        }

        public void DomainToViewModelForCountry()
        {
            CreateMap<Country, DropDownIdNameViewModel>()
                .ForMember(dest => dest.Id, m => m.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, m => m.MapFrom(src => src.CountryName));
        }

        public void DomainToViewModelForCounty()
        {
            CreateMap<County, DropDownIdNameViewModel>()
                .ForMember(dest => dest.Id, m => m.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, m => m.MapFrom(src => src.CountyName));
        }

        public void DomainToViewModelForCity()
        {
            CreateMap<City, DropDownIdNameViewModel>()
                .ForMember(dest => dest.Id, m => m.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, m => m.MapFrom(src => src.CityName));
        }

        public void DomainToViewModelForVehicleBrand()
        {
            CreateMap<VehicleBrand, DropDownNameValueViewModel>()
                .ForMember(dest => dest.Code, m => m.MapFrom(src => src.Code))
                .ForMember(dest => dest.Name, m => m.MapFrom(src => src.BrandName));
        }

        public void DomainToViewModelForVehicleModel()
        {
            CreateMap<VehicleModel, DropDownNameValueViewModel>()
                .ForMember(dest => dest.Code, m => m.MapFrom(src => src.Code))
                .ForMember(dest => dest.Name, m => m.MapFrom(src => src.ModelName));
        }

        public void DomainToViewModelForColor()
        {
            CreateMap<Colour, DropDownNameValueViewModel>()
                .ForMember(dest => dest.Code, m => m.MapFrom(src => src.Code))
                .ForMember(dest => dest.Name, m => m.MapFrom(src => src.ColourName));
        }

    }
}